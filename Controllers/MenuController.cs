using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var lista = _context.Menus.Take(15).ToList();
            return View(lista);
        }
        [Authorize(Roles="Administrador")]
        public IActionResult Registro()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }
        [Authorize(Roles="Administrador")]
        [HttpPost]
        /*public Menu Menu {get;set;}   int id*/
        public IActionResult Registro(Menu x)
        {
            
            if (ModelState.IsValid) {
                /*var _Menu = _context.Menus.Where(x=>x.Id == Menu.Id).SingleOrDefault();
                if(_Cliente == null)
                {
                    _context.Menus.Add(Menu);
                }
                else
                {
                    _Menu.Nombre = Menu.Nombre;
                    _Menu.Foto = Menu.Foto;
                    _Menu.Descripcion = Menu.Descripcion;
                    _Menu.Precio = Menu.Precio;
                    _Menu.Puntos = Menu.Puntos;
                    _Menu.CategoriaId = Menu.CategoriaId;
                }
                _context.SaveChanges();
                return RedirectToAction("ver_menus");*/

                _context.Add(x);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = _context.Categorias.ToList();
            return View(x);
        }
        /*public IActionResult ver_menus(){
            ViewBag.Menus = _context.Menus.ToList();
            return View();
        }
        
        public IActionResult Modificar(int id)
        {
            var Menu = _context.Menus.Find(id);
            if(Menu == null)
            {
                return RedirecToAction("ver_menus");
            }            
            return RedirecToAction("Registro");
        }

        
        public IActionResult Eliminar(int id)
        {
            var Menu = _context.Menus.Find(id);
            if(Menu == null)
            {
                return StatusCode(404);
            }
            _context.Menus.Remove(Menu);
            _context.SaveChanges();
            return Redirect("ver_menus");
        }

        */


        public IActionResult Menuxcateg(int id){
            var lista= _context.Menus.Where(x=>x.CategoriaId==id).ToList();
            return View(lista);
        }
        /*
        public IActionResult Comprar(int id){
            var lista= _context.Menus.Where(x=>x.CategoriaId==id).ToList();
            return View(lista);
        }


        */
        
    }
}