using JoseGilFortoul.Bussiness.Hashing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace JoseGilFortoul.Services
{
    public class UsuarioServices
    {
        private static HttpClient client = new HttpClient();
        //private readonly ILogger _logger;

        //public UsuarioServices( ILogger<UsuarioServices> logger)
        //{            
        //    _logger = logger;
        //}

        public async Task<Models.Usuario> Login(string email, string pass)
        {
            try
            {
                Models.Usuario usuario = new Models.Usuario();
                string path = Commons.Constants.url;
                path += $"Usuarios/Login?mail={email}&password={Hashing.Encrypted(pass)}";
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<Models.Usuario>(objectString);
                }

                return usuario;
            }
            catch (Exception ex)
            {
               // _logger.LogError("Error UsuarioServices -> Login:" + ex.Message);
                throw;
            }
        }

        public async Task<bool> Register(string nombre, string apellido, string email, string cardId, string pass)
        {
            try
            {
                Models.Usuario usuario = new Models.Usuario();
                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.Correo = email;
                usuario.Clave = Hashing.Encrypted(pass);
                usuario.CedulaIdentidad = cardId;
                var data = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"Usuarios";
                HttpResponseMessage response = await client.PostAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
               // _logger.LogError("Error UsuarioServices -> Register:" + ex.Message);
                throw;
            }
        }

        public async Task<bool> Recover(string email)
        {
            try
            {
                string path = Commons.Constants.url;
                path += $"Usuarios/ValidateMail?mail={email}";
                HttpResponseMessage response = await client.GetAsync(path);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
              //  _logger.LogError("Error UsuarioServices -> Recover:" + ex.Message);
                throw;
            }
        }

        public async Task<bool> ChangePassword(Models.Usuario model, string pass)
        {
            try
            {
                model.Clave = Hashing.Encrypted(pass);
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"Usuarios/ChangePassword";
                HttpResponseMessage response = await client.PostAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
              //  _logger.LogError("Error UsuarioServices -> ChangePassword:" + ex.Message);
                throw;
            }
        }

        public async Task<Models.Usuario> SearchEntity(string id)
        {
            try
            {
                Models.Usuario usuario = new Models.Usuario();
                string path = Commons.Constants.url;
                path += $"Usuarios/Cedula/{id}";
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<Models.Usuario>(objectString);
                }

                return usuario;
            }
            catch (Exception ex)
            {
              //  _logger.LogError("Error UsuarioServices -> SearchEntity:" + ex.Message);
                throw;
            }
        }

        public async Task<Models.Usuario> SearchEntity(Guid id)
        {
            try
            {
                Models.Usuario usuario = new Models.Usuario();
                string path = Commons.Constants.url;
                path += $"Usuarios/{id}";
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<Models.Usuario>(objectString);
                }

                return usuario;
            }
            catch (Exception ex)
            {
              //  _logger.LogError("Error UsuarioServices -> searchEntity:" + ex.Message);
                throw;
            }
        }

        public async Task<Models.Usuario> SearchEntityByEmail(string email)
        {
            try
            {
                Models.Usuario usuario = new Models.Usuario();
                string path = Commons.Constants.url;
                path += $"Usuarios/Correo/{email}";
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<Models.Usuario>(objectString);
                }

                return usuario;
            }
            catch (Exception ex)
            {
            //    _logger.LogError("Error UsuarioServices -> SearchEntityByEmails:" + ex.Message);
                throw;
            }
        }

        public string EncryptedPassWord(string pass)
        {
            try
            {
                return Hashing.Encrypted(pass);
            }
            catch (Exception ex)
            {
              //   _logger.LogError("Error UsuarioServices -> Login:" + ex.Message);
                throw;
            }
        }
    }
}
