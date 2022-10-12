using ProyectoCampus.Entities;

namespace ProyectoCampus.Models
{
    public class LoginModel
    {
        public UsuarioObj? ValidateLogin(UsuarioObj user, IConfiguration _config)
        {
            //persona.Contrasenna = util.Encrypt(_config, persona.Contrasenna);

            string baseRoute = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(user);
                string route = baseRoute + "api/Login";
                HttpResponseMessage response = client.PostAsync(route, body).GetAwaiter().GetResult();
                
                return response.IsSuccessStatusCode ? response.Content.ReadFromJsonAsync<UsuarioObj>().Result : null;
            }
        }
    }
}
