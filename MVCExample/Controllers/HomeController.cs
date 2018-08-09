﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Participant()
        {
            return View();
        }
        public ActionResult Course()
        {
            return View();
        }
        public ActionResult Store()
        {
            return View();
        }
        public ActionResult JSExercise()
        {
            return View();
        }
    }
}