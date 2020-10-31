using JoseGilFortoul.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class SolicitudCupoServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<Models.SolicitudCupo>> SearchAll()
        {
            try
            {
                List<Models.SolicitudCupo> cupos = new List<Models.SolicitudCupo>();
                string path = Commons.Constants.url;
                path += $"SolicitudCupos";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    cupos = JsonConvert.DeserializeObject<List<Models.SolicitudCupo>>(objectString);
                }

                return cupos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Models.SolicitudCupo>> SearchByUsuario(Guid id)
        {
            try
            {
                List<Models.SolicitudCupo> cupos = new List<Models.SolicitudCupo>();
                string path = Commons.Constants.url;
                path += $"SolicitudCupos/Usuario/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    cupos = JsonConvert.DeserializeObject<List<Models.SolicitudCupo>>(objectString);
                }

                return cupos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.SolicitudCupo> SearchById(Guid id)
        {
            try
            {
                Models.SolicitudCupo cupo = new Models.SolicitudCupo();
                string path = Commons.Constants.url;
                path += $"SolicitudCupos/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    cupo = JsonConvert.DeserializeObject<Models.SolicitudCupo>(objectString);
                }

                return cupo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SolicitudCupo> SearchByIdAlumno(Guid id)
        {
            try
            {
                SolicitudCupo cupo = new SolicitudCupo();
                string path = Commons.Constants.url;
                path += $"SolicitudCupos/Alumno/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    cupo = JsonConvert.DeserializeObject<SolicitudCupo>(objectString);
                }

                return cupo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Save(Models.SolicitudCupo model)
        {
            try
            {
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"SolicitudCupos";
                HttpResponseMessage response = await client.PostAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Update(Models.SolicitudCupo model)
        {
            try
            {
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"SolicitudCupos/{model.Id}";
                HttpResponseMessage response = await client.PutAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
