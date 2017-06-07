﻿using SpodIgly.DAL;
using SpodIgly.Models;
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
            //Genre newGenre = new Genre { Name = "Rock", Description = "Opis gatunku", IconFilename = "1.png" };
            //db.Genres.Add(newGenre);
            //db.SaveChanges();

            var genresList = db.Genres.ToList();

            return View();
        }

        public ActionResult StaticContent(string viewname)
        {

            return View(viewname);
        }
    }
}