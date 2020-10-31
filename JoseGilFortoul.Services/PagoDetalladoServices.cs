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
    public class PagoDetalladoServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<PagoDetallado>> SearchAll()
        {
            try
            {
                List<PagoDetallado> pagos = new List<PagoDetallado>();
                string path = Commons.Constants.url;
                path += $"Alumnos";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    pagos = JsonConvert.DeserializeObject<List<PagoDetallado>>(objectString);
                }

                return pagos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                string path = Commons.Constants.url;
                path += $"Pagos/PagoDetallado/{id}";
                HttpResponseMessage response = await client.DeleteAsync(path);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagoDetallado> SearchById(Guid id)
        {
            try
            {
                PagoDetallado pago = new PagoDetallado();
                string path = Commons.Constants.url;
                path += $"Alumnos/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    pago = JsonConvert.DeserializeObject<PagoDetallado>(objectString);
                }

                return pago;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<decimal> SearchTotalAmount(Guid id)
        {
            try
            {
                decimal total = 0;
                string path = Commons.Constants.url;
                path += $"Pagos/PagoDetallado/MontoTotal/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    total = JsonConvert.DeserializeObject<decimal>(objectString);
                }

                return total;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<PagoDetallado>> SearchByKeyword(string keyword)
        {
            try
            {
                List<PagoDetallado> pagos = new List<PagoDetallado>();
                string path = Commons.Constants.url;
                path += $"Alumnos";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    pagos = JsonConvert.DeserializeObject<List<PagoDetallado>>(objectString);
                }

                return pagos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<PagoDetallado>> SearchByRepresentative(Guid id)
        {
            try
            {
                List<PagoDetallado> pagos = new List<PagoDetallado>();
                string path = Commons.Constants.url;
                path += $"Pagos/PagoDetallado/Representante/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    pagos = JsonConvert.DeserializeObject<List<PagoDetallado>>(objectString);
                }

                return pagos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Save(PagoDetallado model)
        {
            try
            {
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"Pagos/PagoDetallado";
                HttpResponseMessage response = await client.PostAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Update(PagoDetallado model)
        {
            try
            {
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"Alumnos/{model.Id}";
                HttpResponseMessage response = await client.PutAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
