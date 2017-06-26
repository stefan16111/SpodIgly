using SpodIgly.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpodIgly.Controllers
{
    public class StoreController : Controller
    {
        StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult List(string genrename)
        {
            var genre = db.Genres.Include("Albums").Where(g => g.Name.ToUpper() == genrename.ToUpper()).Single();
            var albums = genre.Albums.ToList();

            return View(albums);
        }

        [ChildActionOnly]
        public ActionResult GenresMenu()
        {
            var genres = db.Genres.ToList();

            return PartialView("_GenresMenu", genres);
        }
    }
}