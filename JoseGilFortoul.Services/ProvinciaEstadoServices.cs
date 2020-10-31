using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class ProvinciaEstadoServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<Models.EstadoProvincia>> SearchAll()
        {
            try
            {
                List<Models.EstadoProvincia> provinciaEstados = new List<Models.EstadoProvincia>();
                string path = Commons.Constants.url;
                path += $"ProvinciaEstados";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    provinciaEstados = JsonConvert.DeserializeObject<List<Models.EstadoProvincia>>(objectString);
                }

                return provinciaEstados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Models.EstadoProvincia>> SearchByCountry(int id)
        {
            try
            {
                List<Models.EstadoProvincia> provinciaEstados = new List<Models.EstadoProvincia>();
                string path = Commons.Constants.url;
                path += $"ProvinciaEstados/Pais/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    provinciaEstados = JsonConvert.DeserializeObject<List<Models.EstadoProvincia>>(objectString);
                }

                return provinciaEstados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.EstadoProvincia> SearchById(Guid id)
        {
            try
            {
                Models.EstadoProvincia estado = new Models.EstadoProvincia();
                string path = Commons.Constants.url;
                path += $"ProvinciaEstados/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    estado = JsonConvert.DeserializeObject<Models.EstadoProvincia>(objectString);
                }

                return estado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.EstadoProvincia> SearchByName(string name)
        {
            try
            {
                Models.EstadoProvincia estado = new Models.EstadoProvincia();
                string path = Commons.Constants.url;
                path += $"ProvinciaEstados/Nombre/{name}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    estado = JsonConvert.DeserializeObject<Models.EstadoProvincia>(objectString);
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
