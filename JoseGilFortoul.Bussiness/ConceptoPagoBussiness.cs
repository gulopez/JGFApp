using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class ConceptoPagoBussiness : ICommons<ConceptoPago>
    {
        private static ConceptoPago conceptoPago;
        private static List<ConceptoPago> conceptoPagos;
        private static Services.ConceptoPagoServices service = new Services.ConceptoPagoServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ConceptoPago>> GetAll()
        {
            return await service.SearchAll();
        }

        public Task<ConceptoPago> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ConceptoPago>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(ConceptoPago model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(ConceptoPago model)
        {
            throw new NotImplementedException();
        }
    }
}
