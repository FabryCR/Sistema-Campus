using ProyectoCampus.Entities;

namespace ProyectoCampus.Models
{
    public class EstudianteModel
    {
        public List<EstudianteObj>? ConsultarEstudiantes(IConfiguration _config)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Estudiante/ConsultarEstudiantes";

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<EstudianteObj>>().Result;
                }

                return new List<EstudianteObj>();
            }
        }

        public EstudianteObj? ConsultarEstudiante(IConfiguration _config, int idEstudiante)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Estudiante/ConsultarEstudiante?idEstudiante=" + idEstudiante;

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<EstudianteObj>().Result;
                }

                return new EstudianteObj();
            }
        }

        public EstudianteObj? RegistrarEstudiante(IConfiguration _config, EstudianteObj estudiante)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(estudiante);
                string rutaServicio = rutaBase + "api/Estudiante/RegistrarEstudiante";


                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<EstudianteObj>().Result;
                }

                return new EstudianteObj();
            }
        }

        public EstudianteObj? ActualizarEstudiante(IConfiguration _config, EstudianteObj estudiante)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(estudiante);
                string rutaServicio = rutaBase + "api/Estudiante/ActualizarEstudiante";


                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<EstudianteObj>().Result;
                }

                return new EstudianteObj();
            }
        }

        public string EliminarEstudiante(IConfiguration _config, int id)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Estudiante/EliminarEstudiante?id=" + id;

                HttpResponseMessage respuesta = client.DeleteAsync(rutaServicio).GetAwaiter().GetResult();
                if (respuesta.IsSuccessStatusCode)
                {
                    return ("Se eliminó correctamente");
                }
                return ("No se puede eliminar la entrada\nEs probable que los datos estén siendo utilizados");
            }
        }
    }
}
