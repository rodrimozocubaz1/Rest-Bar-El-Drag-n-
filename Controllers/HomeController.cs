using System;
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
<<<<<<< HEAD
        private RestauranteContext _context;
        public HomeController(RestauranteContext c) {
=======
        private HomeController _context;
        public HomeController(HomeController c) {
>>>>>>> 6f282121e65cba21d7117e0853c8fdd81144db07
            _context = c;
        }
        public IActionResult Index()
        {
            
<<<<<<< HEAD
            return View();
        }

        public IActionResult Nosotros()
=======

            return View();
        }

        public IActionResult Noticia(int id)
        {
            return View(_context.Noticias.Find(id));
        }



        public IActionResult Privacy()
>>>>>>> 6f282121e65cba21d7117e0853c8fdd81144db07
        {
            return View();

        }
        public IActionResult Menu()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Noticias = _context.Menus.ToList();
            return View();
        }

        
    }
}
