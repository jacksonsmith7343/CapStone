using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Capstone_FotoMe.Data;
using Capstone_FotoMe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_FotoMe.Controllers
{
    public class PhotoEnthusiastController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PhotoEnthusiastController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhotoEnthusiastController
        public ActionResult Index()
        {
            PhotoEnthusiast photoEnthusiast = new PhotoEnthusiast();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            photoEnthusiast = _context.PhotoEnthusiasts.Where(p => p.IdentityUserId == userId).Single();
            
                       
            return View("CreatePhotoEnthusiast");
        }

        // GET: PhotoEnthusiastController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhotoEnthusiastController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhotoEnthusiastController/Create
        [HttpPost]
        public async Task<IActionResult> Create(PhotoEnthusiast photoEnthusiast)
        {

            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                photoEnthusiast.IdentityUserId = userId;

                photoEnthusiast.AddressId = photoEnthusiast.Address.AddressId;

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
    }
}
