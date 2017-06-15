using SpodIgly.DAL;
using SpodIgly.Models;
using SpodIgly.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpodIgly.Controllers
{
    public class HomeController : Controller
    {

        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            var genres = db.Genres;

            var newArrivals = db.Albums.Where(a => !a.IsHidden).OrderByDescending(a => a.DateAdded).Take(3).ToList();

            var bestsellers = db.Albums.Where(a => !a.IsHidden && a.IsBestseller).OrderBy(g => Guid.NewGuid()).Take(3).ToList();

            var vm = new HomeViewModel()
            {
                Bestsellers = bestsellers,

                Genres = genres,
                
                NewArrivals = newArrivals
            };

            return View(vm);
        }

        public ActionResult StaticContent(string viewname)
        {

            return View(viewname);
        }
    }
}