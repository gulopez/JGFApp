using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class EstadoServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<Models.Estado>> SearchAll()
        {
            try
            {
                List<Models.Estado> estados = new List<Models.Estado>();
                string path = Commons.Constants.url;
                path += $"Estados";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    estados = JsonConvert.DeserializeObject<List<Models.Estado>>(objectString);
                }

                return estados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.Estado> SearchById(Guid id)
        {
            try
            {
                Models.Estado estado = new Models.Estado();
                string path = Commons.Constants.url;
                path += $"Estados/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    estado = JsonConvert.DeserializeObject<Models.Estado>(objectString);
                }

                return estado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.Estado> SearchByName(string name)
        {
            try
            {
                Models.Estado estado = new Models.Estado();
                string path = Commons.Constants.url;
                path += $"Estados/Nombre/{name}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    estado = JsonConvert.DeserializeObject<Models.Estado>(objectString);
                }

                return estado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
