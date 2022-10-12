using Microsoft.AspNetCore.Mvc;
using ProyectoCampus.Entities;
using ProyectoCampus.Models;
using ProyectoCampus.Models.Filters;

namespace ProyectoCampus.Controllers
{
    [AdminFilter]
    public class EstudianteController : Controller
    {


        private readonly IConfiguration _config;
        EstudianteModel model = new EstudianteModel();

        public EstudianteController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult ListEstudiante()
        {
            var datos = model.ConsultarEstudiantes(_config);
            return View(datos);
        }

        [HttpGet]
        public ActionResult CreateEstudiante()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEstudiante(EstudianteObj estudiante)
        {
            try
            {
                var datos = model.RegistrarEstudiante(_config, estudiante);
                return RedirectToAction("ListEstudiante", "Estudiante");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditEstudiante(int idEstudiante)
        {
            var datos = model.ConsultarEstudiante(_config, idEstudiante);
            return View(datos);
        }


        public ActionResult EditEstudiante(EstudianteObj estudiante)
        {
            try
            {
                var datos = model.ActualizarEstudiante(_config, estudiante);
                return RedirectToAction("ListEstudiante", "Estudiante");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteEstudiante(int id)
        {
            try
            {
                return Ok(model.EliminarEstudiante(_config, id));
            }
            catch
            {
                return View();
            }
        }
    }
}
