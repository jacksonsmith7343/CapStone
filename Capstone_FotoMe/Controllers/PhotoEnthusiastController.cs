using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone_FotoMe.ActionFilters;
using Capstone_FotoMe.Data;
using Capstone_FotoMe.Models;
using Capstone_FotoMe.Services;
using Microsoft.AspNetCore.Http;


namespace Capstone_FotoMe.Controllers
{
    //[ServiceFilter(typeof(GlobalRouting))]
    public class PhotoEnthusiastController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IAPIService _apiCalls;
        private IAPIService apiCalls;

        public PhotoEnthusiastController(ApplicationDbContext context)
        {
            _context = context;
            _apiCalls = apiCalls;
        }

        // GET: PhotoEnthusiastController
        public async Task<IActionResult> Index()
        {
            PhotoEnthusiast photoEnthusiast = new PhotoEnthusiast();
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                photoEnthusiast = _context.PhotoEnthusiasts.Where(p => p.IdentityUserId == userId).Single();
            }
            catch(Exception)
            {
                return RedirectToAction("Create");

            }
            return View(photoEnthusiast);


        }

        // GET: PhotoEnthusiastController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var photoEnthusiast = _context.PhotoEnthusiasts.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            if (photoEnthusiast == null)
            {
                return NotFound();
            }

            return View(photoEnthusiast);

        }


        // GET: PhotoEnthusiastController/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: PhotoEnthusiastController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePhotoEnthusiast(PhotoEnthusiast photoEnthusiast)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                photoEnthusiast.IdentityUserId = userId;

                _context.Add(photoEnthusiast);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(photoEnthusiast);

        }

        // POST: PhotoEnthusiastController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAddressPhotoEnthusiast(Address address)
        {
            if (ModelState.IsValid)
            {
            
            }
            return View();

        }




        // GET: PhotoEnthusiastController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhotoEnthusiastController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhotoEnthusiastController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhotoEnthusiastController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> FindPostRequestsNearMe()
        {
            return View();
        }

        public async Task<ActionResult> SearchPostsInMyArea()
        {
            return View();
        }

        public async Task<ActionResult> ViewMyFriends()
        {
            return View();
        }

        public async Task<ActionResult> PostAPhotoRequest()
        {

            return View("CreatePostRequest");
        }

        // POST: PhotoEnthusiastController/RequestPost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostAPhotoRequest(PhotoRequestPost photoRequestPost)
        {
            if (ModelState.IsValid)
            {
                var geoAddress = photoRequestPost.Address.StreetAddress + ", " + photoRequestPost.Address.City + ", " + photoRequestPost.Address.State;
                GeoCode geocode = await _apiCalls.GoogleGeocoding(geoAddress);
                var lat = geocode.results[0].geometry.location.lat;
                var lng = geocode.results[0].geometry.location.lng;

                photoRequestPost.Address.Latitude = lat;
                photoRequestPost.Address.Longitude = lng;
                _context.Add(photoRequestPost.Address);
                await _context.SaveChangesAsync();

                // _context.Address.Add(gardener.Address);

                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                

                photoRequestPost.AddressId = photoRequestPost.Address.AddressId;

                _context.Add(photoRequestPost);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}
