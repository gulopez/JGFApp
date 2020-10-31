using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class EstadoBussiness : ICommons<Estado>
    {
        private static Estado estado;
        private static List<Estado> estados;
        private static Services.EstadoServices service = new Services.EstadoServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Estado>> GetAll()
        {
            return await service.SearchAll();
        }

        public async Task<Estado> GetById(Guid id)
        {
            return await service.SearchById(id);
        }

        public Task<List<Estado>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(Estado model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(Estado model)
        {
            throw new NotImplementedException();
        }

        public async Task<Estado> GetByName(string name)
        {
            return await service.SearchByName(name);
        }
    }
}
