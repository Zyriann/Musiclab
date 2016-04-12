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
    public class ArtistController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Albums
        public ActionResult Index()
        {
            var artists = db.Artists.Include(a => a.Name);
            return View(artists.ToList());
        }

        public ActionResult ShowArtist(int id)
        {
            var artist = db.Albums
                .Include(a => a.Title)
                .Where(a => a.ArtistID == id);
            return View(artist.ToList());
        }

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
                return RedirectToAction("IndexA");
            }
        }
    }
}