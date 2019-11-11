using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rest_Bar_El_Drag_n_.Models;

namespace PortalNoticias.Controllers
{
    public class NoticiasController : Controller
    {
        private RestauranteContext _context;
        public NoticiasController(RestauranteContext c) {
            _context = c;
        }
        public IActionResult Index()
        {
            var lista = _context.Menus.ToList();
            return View(lista);
        }
        public IActionResult Registro()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Menu x)
        {
            if (ModelState.IsValid) {
                _context.Add(x);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = _context.Categorias.ToList();
            return View(x);
        }
    }
}