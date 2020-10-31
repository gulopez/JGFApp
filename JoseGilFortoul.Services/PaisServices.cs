using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class PaisServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<Models.Pais>> SearchAll()
        {
            try
            {
                List<Models.Pais> paises = new List<Models.Pais>();
                string path = Commons.Constants.url;
                path += $"Paises";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    paises = JsonConvert.DeserializeObject<List<Models.Pais>>(objectString);
                }

                return paises;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.Pais> SearchById(Guid id)
        {
            try
            {
                Models.Pais pais = new Models.Pais();
                string path = Commons.Constants.url;
                path += $"Paises/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    pais = JsonConvert.DeserializeObject<Models.Pais>(objectString);
                }

                return pais;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.Pais> SearchByName(string name)
        {
            try
            {
                Models.Pais pais = new Models.Pais();
                string path = Commons.Constants.url;
                path += $"Paises/Nombre/{name}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    pais = JsonConvert.DeserializeObject<Models.Pais>(objectString);
                }

                return pais;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
