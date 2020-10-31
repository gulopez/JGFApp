using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using JoseGilFortoul.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class ProvinciaEstadoBussiness : ICommons<EstadoProvincia>
    {
        private static EstadoProvincia provinciaEstado;
        private static List<EstadoProvincia> provinciasEstados;
        private static Services.ProvinciaEstadoServices service = new ProvinciaEstadoServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EstadoProvincia>> GetAll()
        {
            return await service.SearchAll();
        }

        public async Task<EstadoProvincia> GetById(Guid id)
        {
            return await service.SearchById(id);
        }

        public Task<List<EstadoProvincia>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(EstadoProvincia model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(EstadoProvincia model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EstadoProvincia>> GetByCountry(int id)
        {
            return await service.SearchByCountry(id);
        }

        public async Task<EstadoProvincia> GetByName(string name)
        {
            return await service.SearchByName(name);
        }
    }
}
