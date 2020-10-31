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
    public class PreInscripcionServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<bool> Save(Models.PreInscripcion preInscripcion)
        {
            try
            {
                var data = JsonConvert.SerializeObject(preInscripcion);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"Inscripciones/PreInscripcion";
                HttpResponseMessage response = await client.PostAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Update(Models.PreInscripcion preInscripcion)
        {
            try
            {
                var data = JsonConvert.SerializeObject(preInscripcion);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"Inscripciones/PreInscripcion";
                HttpResponseMessage response = await client.PostAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PreInscripcion> SearchById(Guid id)
        {
            try
            {
                PreInscripcion preInscripcion = new PreInscripcion();
                string path = Commons.Constants.url;
                path += $"Inscripciones/PreInscripcion/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    preInscripcion = JsonConvert.DeserializeObject<PreInscripcion>(objectString);
                }

                return preInscripcion;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
