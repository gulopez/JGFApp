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
    public class ConceptoPagoServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<ConceptoPago>> SearchAll()
        {
            try
            {
                List<ConceptoPago> conceptos = new List<ConceptoPago>();
                string path = Commons.Constants.url;
                path += $"ConceptosPago";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    conceptos = JsonConvert.DeserializeObject<List<ConceptoPago>>(objectString);
                }

                return conceptos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
