using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class EstadoCivilBussines : ICommons<EstadoCivil>
    {
        private static EstadoCivil estadoCivil;
        private static List<EstadoCivil> estadosCiviles;
        private static Services.EstadoCivilServices service = new Services.EstadoCivilServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EstadoCivil>> GetAll()
        {
            return await service.SearchAll();
        }

        public Task<EstadoCivil> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EstadoCivil>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(EstadoCivil model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(EstadoCivil model)
        {
            throw new NotImplementedException();
        }
    }
}
