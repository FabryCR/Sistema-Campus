using ProyectoCampus.Entities;

namespace ProyectoCampus.Models
{
    public class ProfesorModel
    {

        public List<ProfesorObj>? ConsultarProfesores(IConfiguration _config)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Profesor/ConsultarProfesores";

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<ProfesorObj>>().Result;
                }

                return new List<ProfesorObj>();
            }
        }

        public ProfesorObj? ConsultarProfesor(IConfiguration _config, int idProfesor)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Profesor/ConsultarProfesor?idProfesor=" + idProfesor;

                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ProfesorObj>().Result;
                }

                return new ProfesorObj();
            }
        }

        public ProfesorObj? RegistrarProfesor(IConfiguration _config, ProfesorObj profesor)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(profesor);
                string rutaServicio = rutaBase + "api/Profesor/RegistrarProfesor";


                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ProfesorObj>().Result;
                }

                return new ProfesorObj();
            }
        }

        public ProfesorObj? ActualizarProfesor(IConfiguration _config, ProfesorObj profesor)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(profesor);
                string rutaServicio = rutaBase + "api/Profesor/ActualizarProfesor";


                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<ProfesorObj>().Result;
                }

                return new ProfesorObj();
            }
        }

        public string EliminarProfesor(IConfiguration _config, int id)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Profesor/EliminarProfesor?id=" + id;

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
