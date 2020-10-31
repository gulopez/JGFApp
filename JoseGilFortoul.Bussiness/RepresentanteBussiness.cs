using JoseGilFortoul.Bussiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class RepresentanteBussiness : ICommons<Models.Representante>
    {
        private static Services.RepresentanteServices service = new Services.RepresentanteServices();
        private static ProvinciaEstadoBussiness estado = new ProvinciaEstadoBussiness();
        private static Models.EstadoProvincia modelEstado;

        public async Task<bool> DeleteEntity(Guid id)
        {
            return await service.Delete(id);
        }

        public async Task<List<Models.Representante>> GetAll()
        {
            return await service.SearchAll();
        }

        public async Task<Models.Representante> GetById(Guid id)
        {
            return await service.SearchById(id);
        }

        public async Task<List<Models.Representante>> GetByKeyword(string keyword)
        {
            return await service.SearchByKeyword(keyword);
        }

        public async Task<bool> SaveEntity(Models.Representante model)
        {
            return await service.Save(model);
        }

        public async Task<bool> UpdateEntity(Models.Representante model)
        {
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
            }
            if (model.IdDireccion == Guid.Empty)
            {
                model.Direccion.Id = Guid.NewGuid();
            }
            modelEstado = new Models.EstadoProvincia();
            modelEstado = await estado.GetByName(model.Direccion.EstadoProvincia.Nombre);
            model.IdDireccion = model.Direccion.Id;
            model.Direccion.IdEstadoProvincia = modelEstado.Id;
            model.Direccion.EstadoProvincia = null;
            model.Direccion.FechaModificacion = DateTime.Now;

            return await service.Update(model);
        }

        public async Task<Models.Representante> GetByCardId(string cardId)
        {
            return await service.SearchByCedula(cardId);
        }

        public Models.Representante GetByCardIdSync(string cardId)
        {
            return service.SearchByCedulaSync(cardId);
        }
    }
}
