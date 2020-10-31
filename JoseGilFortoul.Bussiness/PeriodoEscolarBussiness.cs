using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class PeriodoEscolarBussiness : ICommons<Models.PeriodoEscolar>
    {
        private static Models.PeriodoEscolar gradoEscolar;
        private static List<Models.PeriodoEscolar> gradosEscolares;
        private static Services.PeriodoEscolarServices service = new Services.PeriodoEscolarServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PeriodoEscolar>> GetAll()
        {
            return await service.SearchAll();
        }

        public Task<PeriodoEscolar> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PeriodoEscolar>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(PeriodoEscolar model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(PeriodoEscolar model)
        {
            throw new NotImplementedException();
        }
    }
}
