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

        // GET: Genre
        public ActionResult Index()
        {
            var genre = db.Genres.Include(a => a.GenreID);
            return View(genre.ToList());
        }

        public ActionResult ShowGenre(int id)
        {
            var genre = db.Genres
                .Include(a => a.Name)
                .Where(a => a.GenreID == id);
            return View(genre.ToList());
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

        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres.OrderByDescending(g => g.Name), "GenreID", "Name");
            return View();
        }
    }
}