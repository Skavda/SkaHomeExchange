﻿using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Controllers
{
    public class HomeController : Controller
    {
        //pagination
        public ActionResult Index(int Page = 1)
        {
            Double d = (double)(HomeShareDAL.BienEchange.ChargementDesBiens().Count());
            ViewBag.tot = Math.Ceiling(d / 3);
            return View(HomeShareDAL.BienEchange.ChargementPagination(Page));
        }

        //Cf ifnews

        //public ActionResult Index(int Page = 1)
        //{
        //    //renvoyer toutes les news
        //    //return View(IFDAL.News.getAll());

        //    //Pagination par 5
        //    Double d = (double)(IFDAL.News.getAll().Count());
        //    ViewBag.tot = Math.Ceiling(d / 5);
        //    return View(IFDAL.News.getPagination(Page));

        //}


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
    }
}