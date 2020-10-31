using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class EstadoCivilServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<Models.EstadoCivil>> SearchAll()
        {
            try
            {
                List<Models.EstadoCivil> estados = new List<Models.EstadoCivil>();
                string path = Commons.Constants.url;
                path += $"EstadosCiviles";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    estados = JsonConvert.DeserializeObject<List<Models.EstadoCivil>>(objectString);
                }

                return estados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
