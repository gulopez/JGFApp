using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class GradoEscolarBussiness : ICommons<Models.GradoEscolar>
    {
        private static Models.GradoEscolar gradoEscolar;
        private static List<Models.GradoEscolar> gradosEscolares;
        private static Services.GradoEscolarServices service = new Services.GradoEscolarServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GradoEscolar>> GetAll()
        {
            return await service.SearchAll();
        }

        public Task<GradoEscolar> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GradoEscolar>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(GradoEscolar model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(GradoEscolar model)
        {
            throw new NotImplementedException();
        }
    }
}
