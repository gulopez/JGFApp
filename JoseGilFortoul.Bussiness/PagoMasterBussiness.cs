using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class PagoMasterBussiness : ICommons<PagoMaster>
    {
        private static PagoMaster pagoMaster;
        private static List<PagoMaster> pagoMasters;
        private static Services.PagoMasterServices service = new Services.PagoMasterServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PagoMaster>> GetAll()
        {
            return await service.SearchAll();
        }

        public async Task<List<PagoMaster>> GetAllByRepresentative(Guid id)
        {
            return await service.SearchByRepresentative(id);
        }

        public async Task<PagoMaster> GetById(Guid id)
        {
            return await service.SearchById(id);
        }

        public Task<List<PagoMaster>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveEntity(PagoMaster model)
        {
            return await service.Save(model);
        }

        public Task<bool> UpdateEntity(PagoMaster model)
        {
            throw new NotImplementedException();
        }

        public PagoMaster MatchModel(Guid id, Guid idAlumno, Guid idPeriodoEscolar, Guid idConceptoPago, Guid? idMesEscolar, decimal montoPagar)
        {
            pagoMaster = new PagoMaster();
            pagoMaster.Id = id;
            pagoMaster.IdAlumno = idAlumno;
            pagoMaster.IdPeriodoEscolar = idPeriodoEscolar;
            pagoMaster.IdConceptoPago = idConceptoPago;
            pagoMaster.IdMesEscolar = idMesEscolar ?? null;
            pagoMaster.Monto = montoPagar;
            pagoMaster.FechaPago = DateTime.Now;

            return pagoMaster;
        }
    }
}
