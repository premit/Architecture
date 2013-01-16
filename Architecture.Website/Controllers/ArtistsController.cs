using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Architecture.Website.Models;
using Architecture.Website.Services;

namespace Architecture.Website.Controllers
{
    public class ArtistsController : Controller
    {
        private IArtistService _artistSvc;

        public ArtistsController(
                IArtistService artistSvc
            )
        {
            _artistSvc = artistSvc;
        }

        //
        // GET: /Artists/

        public ActionResult Index()
        {
            var artists = _artistSvc.GetArtists();
            return View(artists);
        }

        //
        // GET: /Artists/Details/5

        public ActionResult Details(int id = 0)
        {
            Artist artist = _artistSvc.GetArtistById(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // GET: /Artists/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Artists/Create

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _artistSvc.CreateArtist(artist);
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        //
        // GET: /Artists/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Artist artist = _artistSvc.GetArtistById(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //
        // POST: /Artists/Edit/5

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _artistSvc.UpdateArtist(artist);
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //
        // GET: /Artists/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Artist artist = _artistSvc.GetArtistById(id);
            if (artist == null)
            {
                return HttpNotFound();
            }

            if (!artist.CanDelete)
            {
                ModelState.AddModelError("CanDelete", "This artist cannot be deleted.");
            }

            return View(artist);
        }

        //
        // POST: /Artists/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _artistSvc.DeleteArtist(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}