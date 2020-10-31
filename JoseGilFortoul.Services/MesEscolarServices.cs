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
    public class MesEscolarServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<MesEscolar>> SearchAll()
        {
            try
            {
                List<MesEscolar> meses = new List<MesEscolar>();
                string path = Commons.Constants.url;
                path += $"MesesEscolares";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    meses = JsonConvert.DeserializeObject<List<MesEscolar>>(objectString);
                }

                return meses;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
