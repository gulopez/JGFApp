using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class FormasDePagoBussiness : ICommons<FormaPago>
    {
        private static FormaPago formaDePago;
        private static List<FormaPago> formasDePagos;
        private static Services.FormasDePagoServices service = new Services.FormasDePagoServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FormaPago>> GetAll()
        {
            return await service.SearchAll();
        }

        public Task<FormaPago> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FormaPago>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(FormaPago model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(FormaPago model)
        {
            throw new NotImplementedException();
        }
    }
}
