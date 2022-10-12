using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCampus.Entities;
using ProyectoCampus.Models;
using ProyectoCampus.Models.Filters;


namespace ProyectoCampus.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly IConfiguration _config;
        MatriculaModel model = new MatriculaModel();

        public MatriculaController(IConfiguration config)
        {
            _config = config;
        }

        [AdminFilter]
        [HttpGet]
        public ActionResult ListMatricula()
        {
            var datos = model.ConsultarMatriculas(_config);
            return View(datos);
        }

        [AdminFilter]
        [HttpGet]
        public ActionResult CreateMatricula()
        {
            ViewBag.Estudiantes = model.SelectListEstudiante(_config);
            ViewBag.Cursos = model.SelectListCurso(_config);
            return View();
        }

        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMatricula(MatriculaObj curso)
        {
            try
            {
                var datos = model.RegistrarMatricula(_config, curso);
                return RedirectToAction("ListMatricula", "Matricula");
            }
            catch
            {
                return View();
            }
        }

        [AdminFilter]
        [HttpGet]
        public ActionResult EditMatricula(int idMatricula)
        {
            var datos = model.ConsultarMatricula(_config, idMatricula);
            ViewBag.Estudiantes = model.SelectListEstudiante(_config);
            ViewBag.Cursos = model.SelectListCurso(_config);
            return View(datos);
        }

        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMatricula(MatriculaObj curso)
        {
            try
            {
                var datos = model.ActualizarMatricula(_config, curso);
                return RedirectToAction("ListMatricula", "Matricula");
            }
            catch
            {
                return View();
            }
        }

        [AdminFilter]
        [HttpPost]
        public ActionResult DeleteMatricula(int id)
        {
            try
            {
                return Ok(model.EliminarMatricula(_config, id));
            }
            catch
            {
                return View();
            }
        }

        //---------------------Matrícula Estudiante-------------------------

        [StudentOnlyFilter]
        [HttpGet]
        public ActionResult MatriculasEstudiante()
        {
            string cedula = HttpContext.Session.GetString("Cedula");
            var datos = model.ConsultarMatriculasEstudiante(_config, cedula);
            return View(datos);
        }
    }
}
