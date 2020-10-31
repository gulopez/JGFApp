using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class PagoMasterServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<Models.PagoMaster>> SearchByRepresentative(Guid id)
        {
            try
            {
                List<Models.PagoMaster> pagoMasters = new List<Models.PagoMaster>();
                string path = Commons.Constants.url;
                path += $"Pagos/Representante/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    pagoMasters = JsonConvert.DeserializeObject<List<Models.PagoMaster>>(objectString);
                }

                return pagoMasters;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Models.PagoMaster>> SearchAll()
        {
            try
            {
                List<Models.PagoMaster> pagoMasters = new List<Models.PagoMaster>();
                string path = Commons.Constants.url;
                path += $"PagosMaster";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    pagoMasters = JsonConvert.DeserializeObject<List<Models.PagoMaster>>(objectString);
                }

                return pagoMasters;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Save(Models.PagoMaster model)
        {
            try
            {
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"PagosMaster";
                HttpResponseMessage response = await client.PostAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.PagoMaster> SearchById(Guid id)
        {
            try
            {
                Models.PagoMaster pagoMaster = new Models.PagoMaster();
                string path = Commons.Constants.url;
                path += $"PagosMaster/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    pagoMaster = JsonConvert.DeserializeObject<Models.PagoMaster>(objectString);
                }

                return pagoMaster;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
