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
<<<<<<< HEAD
            var lista = _context.Menus.Take(15).ToList();
            ViewBag.Categorias=_context.Categorias.ToList();
            return View(lista);
=======
            var categorias= _context.Categorias.Include(x => x.Menus).ToList();
           // var lista = _context.Menus.Take(15).ToList();
            return View(categorias);
>>>>>>> 81cc58372a54eab8ced499b9138ce09b2e63b1eb
        }
        [Authorize(Roles="Administrador")]
        public IActionResult Registro()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }
        [Authorize(Roles="Administrador")]
        [HttpPost]
        
        public IActionResult Registro(Menu x)
        {
            /*
            var Menu = _context.Menus.Where(x=> x.Id==Id).SingleOrDefault();*/
            if (ModelState.IsValid) {
                _context.Add(x);
                _context.SaveChanges();
                return RedirectToAction("index");
                /*var _Menu = _context.Menus.Where(x=>x.Id == Menu.Id).SingleOrDefault();
                if(_Menu == null)
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

                
            }
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }
        [Authorize(Roles="Administrador")]
        [HttpPost]
        public IActionResult modificar1(Menu x)
        {
            /*
            var Menu = _context.Menus.Where(x=> x.Id==Id).SingleOrDefault();*/
            if (ModelState.IsValid) {
                _context.Add(x);
                _context.SaveChanges();
                return Redirect("vermenus");
                /*var _Menu = _context.Menus.Where(x=>x.Id == Menu.Id).SingleOrDefault();
                if(_Menu == null)
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

                
            }
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }
        
        public IActionResult vermenus(){
            ViewBag.Menus = _context.Menus.ToList();
            
            return View();
        }
        
        public IActionResult Modificar(int id)
        {
            var Menu = _context.Menus.Find(id);
            if(Menu == null)
            {
                return RedirectToAction("ver_menus");
            }            
            return RedirectToAction("modificar1");
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