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
    public class CarritoCompraServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                string path = Commons.Constants.url;
                path += $"Pagos/Carrito/{id}";
                HttpResponseMessage response = await client.DeleteAsync(path);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CarritoCompra>> SearchAll()
        {
            try
            {
                List<CarritoCompra> carritos = new List<CarritoCompra>();
                string path = Commons.Constants.url;
                path += $"Pagos/Carrito";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    carritos = JsonConvert.DeserializeObject<List<CarritoCompra>>(objectString);
                }

                return carritos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CarritoCompra> SearchById(Guid id)
        {
            try
            {
                CarritoCompra carrito = new CarritoCompra();
                string path = Commons.Constants.url;
                path += $"Pagos/Carrito/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    carrito = JsonConvert.DeserializeObject<CarritoCompra>(objectString);
                }

                return carrito;
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
                path += $"Pagos/Carrito/MontoTotal/{id}";
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

        public async Task<bool> Save(CarritoCompra model)
        {
            try
            {
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"Pagos/Carrito";
                HttpResponseMessage response = await client.PostAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<bool> Update(CarritoCompra model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CarritoCompra>> SearchByRepresentative(Guid id)
        {
            try
            {
                List<CarritoCompra> carritos = new List<CarritoCompra>();
                string path = Commons.Constants.url;
                path += $"Pagos/Carrito/Representante/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    carritos = JsonConvert.DeserializeObject<List<CarritoCompra>>(objectString);
                }

                return carritos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> SearchTotal(Guid id)
        {
            try
            {
                int total = 0;
                string path = Commons.Constants.url;
                path += $"Pagos/Carrito/Total/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    total = JsonConvert.DeserializeObject<int>(objectString);
                }

                return total;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
