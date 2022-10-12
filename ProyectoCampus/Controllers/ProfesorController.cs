using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCampus.Entities;
using ProyectoCampus.Models;
using ProyectoCampus.Models.Filters;


namespace ProyectoCampus.Controllers
{
    [AdminFilter]
    public class ProfesorController : Controller
    {

        private readonly IConfiguration _config;
        ProfesorModel model = new ProfesorModel();

        public ProfesorController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult ListProfesor()
        {
            var datos = model.ConsultarProfesores(_config);
            return View(datos);
        }

        [HttpGet]
        public ActionResult CreateProfesor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfesor(ProfesorObj profesor)
        {
            try
            {
                var datos = model.RegistrarProfesor(_config, profesor);
                return RedirectToAction("ListProfesor", "Profesor");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult EditProfesor(int idProfesor)
        {
            var datos = model.ConsultarProfesor(_config, idProfesor);
            return View(datos);
        }


        [HttpPost]
        public ActionResult EditProfesor(ProfesorObj profesor)
        {
            try
            {
                var datos = model.ActualizarProfesor(_config, profesor);
                return RedirectToAction("ListProfesor", "Profesor");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteProfesor(int id)
        {
            try
            {
                return Ok(model.EliminarProfesor(_config, id));
            }
            catch
            {
                return View();
            }
        }
    }
}
