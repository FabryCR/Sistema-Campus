using Microsoft.AspNetCore.Mvc;
using ProyectoCampus.Entities;
using ProyectoCampus.Models;
using ProyectoCampus.Models.Filters;

namespace ProyectoCampus.Controllers
{
    public class LoginController : Controller
    {
        LoginModel model = new LoginModel();
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [LoggedFilter]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [LoggedFilter]
        [HttpPost]
        public IActionResult Login(UsuarioObj obj)
        {
            try
            {
                var response = model.ValidateLogin(obj, _config);

                if (response != null)
                {
                    if (response.cedula != "El usuario No existe")
                    {
                        if (response.contraseña != "La contraseña es incorrecta")
                        {
                            HttpContext.Session.SetString("Cedula", response.cedula);
                            HttpContext.Session.SetString("Nombre", response.Nombre);
                            HttpContext.Session.SetString("Apellido1", response.Apellido1);
                            HttpContext.Session.SetString("Apellido2", response.Apellido2);
                            HttpContext.Session.SetString("Rol", response.rol);

                            ViewData.Clear();
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewData["LoginPass"] = response.contraseña;
                            return View();
                        }
                    }
                    else
                    {
                        ViewData["LoginCed"] = response.cedula;
                        return View();
                    }
                }
                ViewData["LoginCed"] = "Ocurrió un error, intente más tarde";
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }


        [HttpGet]
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
