using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Music.Models;

namespace Music.Controllers
{
    public class GenreController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Albums
        public ActionResult Index()
        {
            var albums = db.Genres.Include(a => a.Name);
            return View(albums.ToList());
        }

        public ActionResult ShowGenre(int id)
        {
            var albums = db.Albums
                .Include(a => a.Title)
                .Where(a => a.GenreID == id);
            return View(albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                Album album = db.Albums.Include(a => a.Artist).Include(a => a.Genre).Where(a => a.AlbumID == id).Single();

                if (album == null)
                {
                    return HttpNotFound();
                }
                return View(album);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreID,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
