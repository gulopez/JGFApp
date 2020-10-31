using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Services
{
    public class RepresentanteServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                string path = Commons.Constants.url;
                path += $"Representantes/Delete?id={id}";
                HttpResponseMessage response = await client.GetAsync(path);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Models.Representante>> SearchAll()
        {
            try
            {
                List<Models.Representante> representantes = new List<Models.Representante>();
                string path = Commons.Constants.url;
                path += $"Representantes";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    representantes = JsonConvert.DeserializeObject<List<Models.Representante>>(objectString);
                }

                return representantes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.Representante> SearchByCedula(string cardId)
        {
            try
            {
                Models.Representante representante = new Models.Representante();
                string path = Commons.Constants.url;
                path += $"Representantes/Cedula?cardId={cardId}";
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    representante = JsonConvert.DeserializeObject<Models.Representante>(objectString);
                }

                return representante;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.Representante> SearchById(Guid id)
        {
            try
            {
                Models.Representante representante = new Models.Representante();
                string path = Commons.Constants.url;
                path += $"Representantes/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    representante = JsonConvert.DeserializeObject<Models.Representante>(objectString);
                }

                return representante;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Models.Representante>> SearchByKeyword(string keyword)
        {
            try
            {
                List<Models.Representante> representantes = new List<Models.Representante>();
                string path = Commons.Constants.url;
                path += $"Representantes";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    representantes = JsonConvert.DeserializeObject<List<Models.Representante>>(objectString);
                }

                return representantes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Save(Models.Representante model)
        {
            try
            {
                Models.Representante representante = new Models.Representante();
                var data = JsonConvert.SerializeObject(representante);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"Representantes";
                HttpResponseMessage response = await client.PostAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Update(Models.Representante model)
        {
            try
            {
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"Representantes/{model.Id}";
                HttpResponseMessage response = await client.PutAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Models.Representante SearchByCedulaSync(string cardId)
        {
            try
            {
                Models.Representante representante = new Models.Representante();
                string path = Commons.Constants.url;
                path += $"Representantes/Cedula?cardId={cardId}";
                Task<HttpResponseMessage> response = Task.Run(async () => await client.GetAsync(path));
                if (response.Result.IsSuccessStatusCode)
                {
                    var objectString = response.Result.Content.ReadAsStringAsync();
                    representante = JsonConvert.DeserializeObject<Models.Representante>(objectString.Result);
                }

                return representante;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
