using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rest_Bar_El_Drag_n_.Models;

namespace Rest_Bar_El_Drag_n_.Controllers
{
    public class ReservaController : Controller
    {
         private RestauranteContext _context;
        public ReservaController(RestauranteContext c) {
            _context = c;
        }
        public IActionResult Index()
        {
            var lista = _context.Reservas.ToList();
            return View(lista);
        }
        public IActionResult Registro()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Reserva x)
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