﻿using AI_WoundAnalysisSystem.BLL.BusinessObject;
using AI_WoundAnalysisSystem.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AI_WoundAnalysisSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                this.TempData["SucessAlert"] = message;
            }
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
    }
}