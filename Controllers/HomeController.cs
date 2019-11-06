﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rest_Bar_El_Drag_n_.Models;

namespace Rest_Bar_El_Drag_n_.Controllers
{
    public class HomeController : Controller
    {
        private HomeController _context;
        public HomeController(HomeController c) {
            _context = c;
        }
        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult Noticia(int id)
        {
            return View(_context.Noticias.Find(id));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
