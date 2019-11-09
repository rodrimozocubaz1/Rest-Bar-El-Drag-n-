using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rest_Bar_El_Drag_n_.Models;

namespace Rest_Bar_El_Drag_n_.Controllers
{
    public class MenuController : Controller
    {
         private RestauranteContext _context;
        public MenuController(RestauranteContext c) {
            _context = c;
        }
        public IActionResult Index()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View ();
        }
        public IActionResult Menuxcateg(int codigo){
            var menuc = _context.Menus
                                   .Where(x => x.CategoriaId== codigo)
                                   .ToList();

            var viewModel = new IndexViewModel();
            
            viewModel.Menus = menuc;

            return View(viewModel);



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
                return RedirectToAction("Index","Menu");
            }
            ViewBag.Categorias = _context.Categorias.ToList();
            return View(x);
        }

        public IActionResult Compra(int cod){
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("login","Cuenta");
            else{
                var menu = _context.Menus.Find(cod);
                var viewModel = new IndexViewModel();
                ViewBag.Usuarios=_context.Usuarios.ToList();
                viewModel.Menus = menu;
                
                return View(viewModel);
            }
        }
    }
}