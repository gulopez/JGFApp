using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class MesEscolarBussiness : ICommons<MesEscolar>
    {
        private static MesEscolar mesEscolar;
        private static List<MesEscolar> meseseEscolares;
        private static Services.MesEscolarServices service = new Services.MesEscolarServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MesEscolar>> GetAll()
        {
            return await service.SearchAll();
        }

        public Task<MesEscolar> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MesEscolar>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(MesEscolar model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(MesEscolar model)
        {
            throw new NotImplementedException();
        }
    }
}
