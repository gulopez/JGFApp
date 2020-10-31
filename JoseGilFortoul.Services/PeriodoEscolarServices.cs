using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class PeriodoEscolarServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<Models.PeriodoEscolar>> SearchAll()
        {
            try
            {
                List<Models.PeriodoEscolar> periodosEscolares = new List<Models.PeriodoEscolar>();
                string path = Commons.Constants.url;
                path += $"PeriodosEscolares";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    periodosEscolares = JsonConvert.DeserializeObject<List<Models.PeriodoEscolar>>(objectString);
                }

                return periodosEscolares;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
