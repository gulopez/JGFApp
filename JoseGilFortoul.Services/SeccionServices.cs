using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class SeccionServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<Models.Seccion>> SearchAll()
        {
            try
            {
                List<Models.Seccion> secciones = new List<Models.Seccion>();
                string path = Commons.Constants.url;
                path += $"Secciones";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    secciones = JsonConvert.DeserializeObject<List<Models.Seccion>>(objectString);
                }

                return secciones;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
