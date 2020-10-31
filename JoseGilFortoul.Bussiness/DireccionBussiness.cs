using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class DireccionBussiness : ICommons<Direccion>
    {
        private static Direccion direccion;
        private static List<Direccion> direcciones;
        private static Services.DireccionServices service = new Services.DireccionServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Direccion>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Direccion> GetById(Guid id)
        {
            return await service.SearchById(id);
        }

        public Task<List<Direccion>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(Direccion model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(Direccion model)
        {
            throw new NotImplementedException();
        }
    }
}
