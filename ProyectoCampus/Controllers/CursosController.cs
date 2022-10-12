using Microsoft.AspNetCore.Mvc;
using ProyectoCampus.Entities;
using ProyectoCampus.Models;
using ProyectoCampus.Models.Filters;

namespace ProyectoCampus.Controllers
{
    [AdminFilter]
    public class CursosController : Controller
    {

        private readonly IConfiguration _config;
        CursosModel model = new CursosModel();

        public CursosController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult ListCurso()
        {
            var datos = model.ConsultarCursos(_config);
            return View(datos);
        }

        [HttpGet]
        public ActionResult CreateCurso()
        {
            ViewBag.Profesores = model.SelectListProfesores(_config);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCurso(CursosObj curso)
        {
            try
            {
                var datos = model.RegistrarCurso(_config, curso);
                return RedirectToAction("ListCurso", "Cursos");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditCurso(int idCurso)
        {
            var datos = model.ConsultarCurso(_config, idCurso);
            ViewBag.Profesores = model.SelectListProfesores(_config);
            return View(datos);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCurso(CursosObj curso)
        {
            try
            {
                var datos = model.ActualizarCurso(_config, curso);
                return RedirectToAction("ListCurso", "Cursos");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteCurso(int id)
        {
            try
            {
                return Ok(model.EliminarCurso(_config, id));
            }
            catch
            {
                return View();
            }
        }
    }
}
