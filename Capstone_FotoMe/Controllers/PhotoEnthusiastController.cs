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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.CodeAnalysis.Differencing;

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
        public async Task<ActionResult> Details()
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

        //public async Task<List<PhotoRequestPost>> SearchPhotoEnthusiasts()
        //{
        //    List<PhotoEnthusiast> allPhotoEnthusiasts = new List<PhotoEnthusiast>();

        //    return allPhotoEnthusiasts;

        //}

      
        
        
        public async Task<ActionResult> PostRequestsNearMe()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var photoEnthusiast = _context.PhotoEnthusiasts.Where(p => p.IdentityUserId == userId).SingleOrDefault();
            var address = _context.Addresses.Where(a => a.AddressId == photoEnthusiast.AddressId).SingleOrDefault();


            var nearbyPhotoRequestPosts = _context.PhotoRequestPosts.Include(p => p.Address);
            var photoEnthusiastAddress = photoEnthusiast.Address.State;
            var matchedPhotoRequestPosts = nearbyPhotoRequestPosts.Where(m => m.Address.City == address.City).ToList();
          
            return View(matchedPhotoRequestPosts);
            
        }







        
        public async Task<ActionResult> SeeRequests()
        {

            var allFriendRequests = _context.PhotoEnthusiasts.Where(r => r.SendFriendRequest == false);
            return View(allFriendRequests);
            
        }

        
        [HttpPost]
        public async Task<ActionResult> SeeRequests(int id)
        {

            var allFriendRequests = _context.PhotoEnthusiasts.Where(r => r.SendFriendRequest == false);
            return View(allFriendRequests);

        }

        public async Task<ActionResult> AcceptRequest(int id)
        {
            var requestee = _context.PhotoEnthusiasts.Where(e => e.PhotoEnthusiastId == id).SingleOrDefault();

          
            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> AcceptRequest()
        //{
        //    var requestee = _context.PhotoEnthusiasts.Where(e => e.PhotoEnthusiastId == id).SingleOrDefault();


        //    return View();
        //}


        public async Task<ActionResult> AddFriend(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var photoEnthusiast = _context.PhotoEnthusiasts.Where(e => e.PhotoEnthusiastId == id).SingleOrDefault();
           // var friend = _context.PhotoEnthusiasts.Where(f => f.IdentityUserId == userId).SingleOrDefault();

           
            return View(photoEnthusiast);
        }

        [HttpPost]
        public async Task<ActionResult> AddFriend(int id, bool IsAccepted)
        {
            Friend friend = new Friend();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var photoEnthusiast = _context.PhotoEnthusiasts.Where(e => e.IdentityUserId == userId).SingleOrDefault();

            var requestee = _context.PhotoEnthusiasts.Where(e => e.PhotoEnthusiastId == id).SingleOrDefault();
            friend.RequesterPhotoEnthusiastId = photoEnthusiast.PhotoEnthusiastId;
            friend.RequesteePhotoEnthusiastId = requestee.PhotoEnthusiastId;
            

            _context.Friends.Add(friend);
            await _context.SaveChangesAsync();

            return View();
        }


        public async Task<ActionResult> PostAPhotoRequest()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var photoEnthusiast = _context.PhotoEnthusiasts.Where(e => e.IdentityUserId == userId).SingleOrDefault();
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

                _context.PhotoRequestPosts.Add(photoRequestPost);

                await _context.SaveChangesAsync();
                return RedirectToAction();
            }
            return View();
        }






        /// <summary>
        /// ////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        /// 


        public async Task<ActionResult> GetAllPhotoEnthusiasts()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var photoEnthusiast = _context.PhotoEnthusiasts.Where(p => p.IdentityUserId == userId).SingleOrDefault();
            var photoEnthusiasts = _context.PhotoEnthusiasts;

            return View();
        }

        //public async Task<List<PhotoEnthusiast>> AllPhotoEnthusiasts()
        //{
        //    List<PhotoEnthusiast> allPhotoEnthusiasts = new List<PhotoEnthusiast>();

        //    //var allPhotoRequestPosts = _context.PhotoRequestPosts;

        //    return allPhotoEnthusiasts;

        //}

        //GET
        public ActionResult SearchByCriteria()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var model = _context.PhotoEnthusiasts.Where(p => p.IdentityUserId == userId).SingleOrDefault();
            var model = _context.PhotoEnthusiasts;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchByCriteria(SearchByCriteriaViewModel model)
        {

            var photoEnthusiasts = _context.PhotoEnthusiasts.ToList();
            var addresses = _context.Addresses;


            if (model.SearchByPrice == true)
            {
                photoEnthusiasts = photoEnthusiasts.Where(p => p.PriceForService == model.Price).ToList();
            }

            if (model.SearchByRating == true)
            {

                photoEnthusiasts = photoEnthusiasts.Where(p => p.Rating == model.Rating).ToList();
            }

            if (model.SearchByCity == true)
            {
               
                var matchingAddresses = addresses.Where(a => a.City == model.City);
                //Declare a list/collection of PEs
                //foreach through matchingaddresses and run this query on each address to find the corresponding PE
                //Add photoEnthusiasts.Clear(); that PE to the list/collection you declared earlier
                photoEnthusiasts.Clear();
                foreach (Address address in matchingAddresses)
                {
                    var peToAdd = photoEnthusiasts.Where(p => p.AddressId == address.AddressId).FirstOrDefault();
                    photoEnthusiasts.Add(peToAdd);
                }
                
            }

            return View("GetAllPhotoEnthusiasts", photoEnthusiasts);

        }

        
        public async Task<IActionResult> UploadImage()
        {

            return View();
        }




    }
}
