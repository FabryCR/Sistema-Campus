using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoCampus.Entities;

namespace ProyectoCampus.Models
{
    public class MatriculaModel
    {
        public List<MatriculaObj>? ConsultarMatriculas(IConfiguration _config)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Matricula/ConsultarMatriculas";

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<MatriculaObj>>().Result;
                }

                return new List<MatriculaObj>();
            }
        }

        public MatriculaObj? ConsultarMatricula(IConfiguration _config, int idMatricula)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Matricula/ConsultarMatricula?idMatricula=" + idMatricula;

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<MatriculaObj>().Result;
                }

                return new MatriculaObj();
            }
        }

        public MatriculaObj? RegistrarMatricula(IConfiguration _config, MatriculaObj curso)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(curso);
                string rutaServicio = rutaBase + "api/Matricula/RegistrarMatricula";


                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<MatriculaObj>().Result;
                }

                return new MatriculaObj();
            }
        }


        public MatriculaObj? ActualizarMatricula(IConfiguration _config, MatriculaObj curso)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(curso);
                string rutaServicio = rutaBase + "api/Matricula/ActualizarMatricula";


                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<MatriculaObj>().Result;
                }

                return new MatriculaObj();
            }
        }


        public string EliminarMatricula(IConfiguration _config, int id)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Matricula/EliminarMatricula?id=" + id;

                HttpResponseMessage respuesta = client.DeleteAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return ("Se eliminó correctamente");
                }
                return ("No se puede eliminar la entrada\nEs probable que los datos estén siendo utilizados");
            }
        }

        public List<SelectListItem>? SelectListEstudiante(IConfiguration _config)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Matricula/SelectListEstudiante";

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
                }
                return new List<SelectListItem>();
            }
        }

        public List<SelectListItem>? SelectListCurso(IConfiguration _config)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Matricula/SelectListCurso";

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
                }
                return new List<SelectListItem>();
            }
        }

        //---------------------Matrícula Estudiante-------------------------
        public List<MatriculaObj>? ConsultarMatriculasEstudiante(IConfiguration _config, string cedula)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Matricula/ConsultarMatriculasEstudiante?cedula=" + cedula;

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<MatriculaObj>?>().Result;
                }

                return new List<MatriculaObj>();
            }
        }
    }
}
