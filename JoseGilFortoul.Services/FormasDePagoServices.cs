using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class FormasDePagoServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<Models.FormaPago>> SearchAll()
        {
            try
            {
                List<Models.FormaPago> pagos = new List<Models.FormaPago>();
                string path = Commons.Constants.url;
                path += $"FormasDePagos";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    pagos = JsonConvert.DeserializeObject<List<Models.FormaPago>>(objectString);
                }

                return pagos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
