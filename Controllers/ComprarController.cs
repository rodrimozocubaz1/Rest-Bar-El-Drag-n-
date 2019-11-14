using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rest_Bar_El_Drag_n_.Models;

namespace Rest_Bar_El_Drag_n_.Controllers
{
   public class ComprarController: Controller
    {
        private RestauranteContext _context;
        public ComprarController(RestauranteContext c) {
            _context = c;
        }

        public IActionResult registro(int id)
        {
            ViewBag.Menus = _context.Menus.Where(x=> x.Id==id).Single();
            
            
            return View();
        }
        
        public IActionResult ComprarConf(Compra c)
        {
            if(ModelState.IsValid){
                var _user = User.Identity.Name;
                c.UsuarioId=_user;
                //_context.Usuario.
                c.Total=c.Cantidad*c.Menu.Precio;
                _context.Add(c);
                _context.SaveChanges();
                return RedirectToAction("ver_listadoU");
            }
            
            return View();
        }
        [Authorize(Roles="Usuario")]
        public IActionResult ver_listadoU(){
            var user= User.Identity.Name;
            ViewBag.Compras= _context.Compras.OrderByDescending(x=>x.Fecha).Where(x=> x.UsuarioId==user).ToList();
            return View();


        }

        [Authorize(Roles="Administrador")]
        public IActionResult ver_listadoA(){
            ViewBag.Compras= _context.Compras.OrderByDescending(x=>x.Fecha).ToList();
            
            return View();


        }

    }
}