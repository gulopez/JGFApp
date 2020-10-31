using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class GradoEscolarServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<Models.GradoEscolar>> SearchAll()
        {
            try
            {
                List<Models.GradoEscolar> gradosEscolares = new List<Models.GradoEscolar>();
                string path = Commons.Constants.url;
                path += $"GradosEscolares";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    gradosEscolares = JsonConvert.DeserializeObject<List<Models.GradoEscolar>>(objectString);
                }

                return gradosEscolares;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
