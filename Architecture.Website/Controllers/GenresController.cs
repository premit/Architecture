using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Architecture.Domain;

namespace Architecture.Website.Controllers
{
    public class GenresController : Controller
    {
        private IGenreService _genreSvc;

        public GenresController(
                IGenreService genreSvc
            )
        {
            if (genreSvc == null)
                throw new ArgumentNullException("genreSvc");

            _genreSvc = genreSvc;
        }

        //
        // GET: /Genres/

        public ActionResult Index(int page = 1)
        {
            var genres = _genreSvc.GetGenres();
            return View(genres);
        }

        //
        // GET: /Genres/Details/5

        public ActionResult Details(int id = 0)
        {
            Genre genre = _genreSvc.GetGenreById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // GET: /Genres/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Genres/Create

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreSvc.CreateGenre(genre);
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        //
        // GET: /Genres/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Genre genre = _genreSvc.GetGenreById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // POST: /Genres/Edit/5

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreSvc.UpdateGenre(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        //
        // GET: /Genres/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Genre genre = _genreSvc.GetGenreById(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        //
        // POST: /Genres/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _genreSvc.DeleteGenre(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}