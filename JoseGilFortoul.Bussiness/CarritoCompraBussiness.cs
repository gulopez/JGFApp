using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class CarritoCompraBussiness : ICommons<CarritoCompra>
    {
        private static CarritoCompra carrito;
        private static List<CarritoCompra> carritos;
        private static Services.CarritoCompraServices service = new Services.CarritoCompraServices();

        public async Task<bool> DeleteEntity(Guid id)
        {
            return await service.Delete(id);
        }

        public async Task<List<CarritoCompra>> GetAll()
        {
            return await service.SearchAll();
        }

        public async Task<CarritoCompra> GetById(Guid id)
        {
            return await service.SearchById(id);
        }

        public Task<List<CarritoCompra>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveEntity(CarritoCompra model)
        {
            return await service.Save(model);
        }

        public async Task<bool> UpdateEntity(CarritoCompra model)
        {
            return await service.Update(model);
        }

        public async Task<List<CarritoCompra>> GetByRepresentative(Guid id)
        {
            return await service.SearchByRepresentative(id);
        }

        public async Task<int> GetTotal(Guid id)
        {
            return await service.SearchTotal(id);
        }

        public CarritoCompra MatchModel(Guid id, Guid idPeriodoEscolar, Guid idConceptoPago, Guid? idMesEscolar)
        {
            carrito = new CarritoCompra();
            carrito.Id = Guid.NewGuid();
            carrito.IdAlumno = id;
            carrito.IdPeriodoEscolar = idPeriodoEscolar;
            carrito.IdConceptoPago = idConceptoPago;
            if (idMesEscolar != null)
            {
                carrito.IdMesEscolar = idMesEscolar;
            }
            carrito.MontoPagar = Convert.ToDecimal(3456791.98);

            return carrito;
        }

        public async Task<decimal> GetTotalAmount(Guid id)
        {
            return await service.SearchTotalAmount(id);
        }
    }
}
