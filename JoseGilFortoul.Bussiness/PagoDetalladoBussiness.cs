using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class PagoDetalladoBussiness : ICommons<PagoDetallado>
    {
        private static PagoDetallado pagoDetallado;
        private static List<PagoDetallado> pagoDetallados;
        private static Services.PagoDetalladoServices service = new Services.PagoDetalladoServices();

        public async Task<bool> DeleteEntity(Guid id)
        {
            return await service.Delete(id);
        }

        public async Task<List<PagoDetallado>> GetAll()
        {
            return await service.SearchAll();
        }

        public async Task<PagoDetallado> GetById(Guid id)
        {
            return await service.SearchById(id);
        }

        public Task<List<PagoDetallado>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveEntity(PagoDetallado model)
        {
            return await service.Save(model);
        }

        public Task<bool> UpdateEntity(PagoDetallado model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PagoDetallado>> GetByRepresentative(Guid id)
        {
            return await service.SearchByRepresentative(id);
        }

        public PagoDetallado MatchModel(Guid idFormaPago, string referencia, decimal monto, Guid idRepresentante)
        {
            pagoDetallado = new PagoDetallado();
            pagoDetallado.Id = Guid.NewGuid();
            pagoDetallado.IdFormaPago = idFormaPago;
            pagoDetallado.Referencia = referencia;
            pagoDetallado.Monto = monto;
            pagoDetallado.IdRepresentante = idRepresentante;

            return pagoDetallado;
        }

        public async Task<decimal> GetTotalAmount(Guid id)
        {
            return await service.SearchTotalAmount(id);
        }
    }
}
