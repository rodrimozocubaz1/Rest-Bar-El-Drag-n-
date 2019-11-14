using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rest_Bar_El_Drag_n_.Models;

namespace Rest_Bar_El_Drag_n_.Controllers
{
    
    public class CuentaController : Controller
    {
        private RestauranteContext _context;
        private SignInManager<Usuario> _sim;
        private UserManager<Usuario> _um;
        private RoleManager<IdentityRole> _rm;
        public CuentaController(
            RestauranteContext c,  
            SignInManager<Usuario> s,
            UserManager<Usuario> um,
            RoleManager<IdentityRole> rm) {

            _context = c;
            _sim = s;
            _um = um;
            _rm = rm;
        }
        [Authorize(Roles="Administrador")]
        public IActionResult AsociarRol()
        {
            ViewBag.Usuarios = _context.Usuarios.ToList();
            ViewBag.Roles = _rm.Roles.ToList();

            return View();
        }
        [Authorize(Roles="Administrador")]
        [HttpPost]
        public IActionResult AsociarRol(string usuario, string rol) {
            var user = _context.Usuarios.Where(x=> x.Id==usuario).Single();

            var resultado = _um.AddToRoleAsync(user, rol).Result;

            return RedirectToAction("index", "home");
        }
        [Authorize(Roles="Administrador")]
        public IActionResult CrearRol()
        {
            return View();
        }
        [Authorize(Roles="Administrador")]
        [HttpPost]
        public IActionResult CrearRol(string nombre)
        {
            var rol = new IdentityRole();
            rol.Name = nombre;

            var resultado = _rm.CreateAsync(rol).Result;

            return RedirectToAction("index", "home");
        }

        public IActionResult Crear() {
            return View();
        }

        public IActionResult AccesoDenegado() {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(CrearCuentaViewModel model) {
            if (ModelState.IsValid) {
                // Guardar datos del modelo en la tabla usuarios
                var usuario = new Usuario();
                usuario.Nombre = model.Nombre;
                usuario.Apellidos = model.Apellidos;
                usuario.Telefono = model.Telefono;
                usuario.Puntos = model.Puntos;
                usuario.Email = model.Correo;
                usuario.UserName = model.Correo;
                ViewBag.Usuarios= _context.Usuarios.ToList();
                IdentityResult resultado = _um.CreateAsync(usuario, model.Password1).Result;
                var r = _um.AddToRoleAsync(usuario, "Usuario").Result;


                
            if (resultado.Succeeded) {
                    return RedirectToAction("login", "cuenta");
                }
                else {
                    foreach (var item in resultado.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }                
            }

            return View(model);
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model) {

            if (ModelState.IsValid) {

             
                var resultado = _sim.PasswordSignInAsync(model.Correo, model.Password, true, false).Result;

                if (resultado.Succeeded) {

                    return RedirectToAction("index", "home");
                }
                else {
                    
                    ModelState.AddModelError("", "Datos incorrectos");
                }
            }        

            return View(model);
        }

        public IActionResult Logout() {
            _sim.SignOutAsync();

            return RedirectToAction("index", "home");
        }
    }
}