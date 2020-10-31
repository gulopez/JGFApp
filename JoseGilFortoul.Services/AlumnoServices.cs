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
    public class AlumnoServices
    {
        private static HttpClient client = new HttpClient();

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                string path = Commons.Constants.url;
                path += $"Alumnos/Delete?id={id}";
                HttpResponseMessage response = await client.DeleteAsync(path);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Models.Alumno>> SearchAll()
        {
            try
            {
                List<Models.Alumno> alumnos = new List<Models.Alumno>();
                string path = Commons.Constants.url;
                path += $"Alumnos";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    alumnos = JsonConvert.DeserializeObject<List<Models.Alumno>>(objectString);
                }

                return alumnos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Models.Alumno> SearchById(Guid id)
        {
            try
            {
                Models.Alumno alumno = new Models.Alumno();
                string path = Commons.Constants.url;
                path += $"Alumnos/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    alumno = JsonConvert.DeserializeObject<Models.Alumno>(objectString);
                }

                return alumno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Models.Alumno>> SearchByKeyword(string keyword)
        {
            try
            {
                List<Models.Alumno> alumnos = new List<Models.Alumno>();
                string path = Commons.Constants.url;
                path += $"Alumnos/Buscar/{keyword}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    alumnos = JsonConvert.DeserializeObject<List<Models.Alumno>>(objectString);
                }

                return alumnos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Models.Alumno>> SearchByRepresentative(Guid id)
        {
            try
            {
                List<Models.Alumno> alumnos = new List<Models.Alumno>();
                string path = Commons.Constants.url;
                path += $"Alumnos/Representante/{id}";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    alumnos = JsonConvert.DeserializeObject<List<Models.Alumno>>(objectString);
                }

                return alumnos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Save(Models.Alumno model)
        {
            try
            {
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                string path = Commons.Constants.url;
                path += $"Alumnos";
                HttpResponseMessage response = await client.PostAsync(path, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Update(Models.Alumno model)
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

        public async Task<bool> SearchIfExists(string cardId)
        {
            try
            {
                string path = Commons.Constants.url;
                path += $"Alumnos/Existe/Cedula/{cardId}";
                HttpResponseMessage response = await client.GetAsync(path);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Alumno>> SearchByPreInscription()
        {
            try
            {
                List<Alumno> alumnos = new List<Alumno>();
                string path = Commons.Constants.url;
                path += $"Alumnos/PreInscripcion";
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var objectString = await response.Content.ReadAsStringAsync();
                    alumnos = JsonConvert.DeserializeObject<List<Alumno>>(objectString);
                }

                return alumnos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
