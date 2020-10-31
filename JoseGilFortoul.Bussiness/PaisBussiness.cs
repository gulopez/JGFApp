using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class PaisBussiness : ICommons<Pais>
    {
        private static Pais pais;
        private static List<Pais> paises;
        private static Services.PaisServices service = new Services.PaisServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pais>> GetAll()
        {
            return await service.SearchAll();
        }

        public async Task<Pais> GetById(Guid id)
        {
            return await service.SearchById(id);
        }

        public Task<List<Pais>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(Pais model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(Pais model)
        {
            throw new NotImplementedException();
        }

        public async Task<Pais> GetByName(string name)
        {
            return await service.SearchByName(name);
        }
    }
}
