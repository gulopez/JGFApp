using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class DireccionServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<Models.Direccion> SearchById(Guid id)
        {
            try
            {
                Models.Direccion direccion = new Models.Direccion();
                string path = Commons.Constants.url;
                path += $"Direcciones/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    direccion = JsonConvert.DeserializeObject<Models.Direccion>(objectString);
                }

                return direccion;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
