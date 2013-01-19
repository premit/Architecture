using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Architecture.Domain;
using Architecture.Website.Helpers;

namespace Architecture.Website.Controllers
{
    public class AlbumsController : Controller
    {
        private IGenreService _genreSvc;
        private IArtistService _artistSvc;
        private IAlbumService _albumSvc;

        public AlbumsController(
                IGenreService genreSvc,
                IArtistService artistSvc,
                IAlbumService albumSvc
            )
        {
            if (genreSvc == null)
                throw new ArgumentNullException("genreSvc");
            if (artistSvc == null)
                throw new ArgumentNullException("artistSvc");
            if (albumSvc == null)
                throw new ArgumentNullException("albumSvc");

            _genreSvc = genreSvc;
            _artistSvc = artistSvc;
            _albumSvc = albumSvc;
        }

        //
        // GET: /Albums/

        public ActionResult Index()
        {
            var albums = _albumSvc.GetAlbums();
            return View(albums);
        }

        //
        // GET: /Albums/Details/5

        public ActionResult Details(int id = 0)
        {
            Album album = _albumSvc.GetAlbumById(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // GET: /Albums/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(_genreSvc.GetGenres(), "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(_artistSvc.GetArtists(), "ArtistId", "Name");
            return View();
        }

        //
        // POST: /Albums/Create

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                _albumSvc.CreateAlbum(album);
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(_genreSvc.GetGenres(), "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_artistSvc.GetArtists(), "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // GET: /Albums/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Album album = _albumSvc.GetAlbumById(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(_genreSvc.GetGenres(), "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_artistSvc.GetArtists(), "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // POST: /Albums/Edit/5

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _albumSvc.UpdateAlbum(album);
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(_genreSvc.GetGenres(), "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_artistSvc.GetArtists(), "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // GET: /Albums/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Album album = _albumSvc.GetAlbumById(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // POST: /Albums/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _albumSvc.DeleteAlbum(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}