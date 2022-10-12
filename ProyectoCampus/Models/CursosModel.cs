using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoCampus.Entities;

namespace ProyectoCampus.Models
{
    public class CursosModel
    {

        public List<CursosObj>? ConsultarCursos(IConfiguration _config)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Curso/ConsultarCursos";

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<CursosObj>>().Result;
                }

                return new List<CursosObj>();
            }
        }

        public CursosObj? ConsultarCurso(IConfiguration _config, int idCurso)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Curso/ConsultarCurso?idCurso=" + idCurso;

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<CursosObj>().Result;
                }

                return new CursosObj();
            }
        }

        public CursosObj? RegistrarCurso(IConfiguration _config, CursosObj curso)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(curso);
                string rutaServicio = rutaBase + "api/Curso/RegistrarCurso";


                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<CursosObj>().Result;
                }

                return new CursosObj();
            }
        }


        public CursosObj? ActualizarCurso(IConfiguration _config, CursosObj curso)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(curso);
                string rutaServicio = rutaBase + "api/Curso/ActualizarCurso";


                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<CursosObj>().Result;
                }

                return new CursosObj();
            }
        }


        public string EliminarCurso(IConfiguration _config, int id)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Curso/EliminarCurso?id=" + id;

                HttpResponseMessage respuesta = client.DeleteAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return ("Se eliminó correctamente");
                }
                return ("No se puede eliminar la entrada\nEs probable que los datos estén siendo utilizados");
            }
        }


        public List<SelectListItem>? SelectListProfesores(IConfiguration _config)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Curso/SelectListProfesores";

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();
                
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
                }
                return new List<SelectListItem>();
            }
        }
    }
}
