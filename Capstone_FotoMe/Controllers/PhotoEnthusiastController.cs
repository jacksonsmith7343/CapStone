using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone_FotoMe.ActionFilters;
using Capstone_FotoMe.Data;
using Capstone_FotoMe.Models;

using Microsoft.AspNetCore.Http;
using System.Security.Cryptography.X509Certificates;
using Capstone_FotoMe.Services;

namespace Capstone_FotoMe.Controllers
{
    //[ServiceFilter(typeof(GlobalRouting))]
    public class PhotoEnthusiastController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IAPIService _apiCalls;

        public PhotoEnthusiastController(ApplicationDbContext context, IAPIService apiCalls)
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var photoEnthusiast = _context.PhotoEnthusiasts.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            return View();
        }

        // POST: PhotoEnthusiastController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhotoEnthusiast photoEnthusiast)
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
            return View();
        }

        // POST: PhotoEnthusiastController/RequestPost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostAPhotoRequest(PhotoRequestPost photoRequestPost)
        {
            //var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var photoEnthusiast = _context.PhotoEnthusiasts.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            photoRequestPost.PhotoEnthusiastId = photoEnthusiast.PhotoEnthusiastId;


            

            if (ModelState.IsValid)
            {
                var geoAddress = photoRequestPost.Address.StreetAddress + ", " + photoRequestPost.Address.City + ", " + photoRequestPost.Address.State;
                GeoCode geocode = await _apiCalls.Geocoding(geoAddress);
                var lat = geocode.results[0].geometry.location.lat;
                var lng = geocode.results[0].geometry.location.lng;

                photoRequestPost.Address.Latitude = lat;
                photoRequestPost.Address.Longitude = lng;
                _context.Addresses.Add(photoRequestPost.Address);
                await _context.SaveChangesAsync();



                //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                _context.PhotoRequestPosts.Add(photoRequestPost);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}
