using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class SolicitudCupoBussiness : ICommons<SolicitudCupo>
    {
        private static SolicitudCupo cupo;
        private static List<SolicitudCupo> cupos;
        private static EstadoBussiness estado = new EstadoBussiness();
        private static Services.SolicitudCupoServices service = new Services.SolicitudCupoServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SolicitudCupo>> GetAll()
        {
            return await service.SearchAll();
        }

        public async Task<List<SolicitudCupo>> GetByUsuario(Guid id)
        {
            return await service.SearchByUsuario(id);
        }

        public async Task<SolicitudCupo> GetById(Guid id)
        {
            return await service.SearchById(id);
        }

        public Task<List<SolicitudCupo>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveEntity(SolicitudCupo model)
        {
            return await service.Save(model);
        }

        public async Task<bool> UpdateEntity(SolicitudCupo model)
        {
            return await service.Update(model);
        }

        public async Task<SolicitudCupo> MatchModel(SolicitudCupo model, Guid idUsuario, Alumno modelAlumno)
        {
            model.Id = Guid.NewGuid();
            model.IdUsuario = idUsuario;
            model.IdAlumno = modelAlumno.Id;
            model.PrimerNombre = modelAlumno.PrimerNombre;
            model.SegundoNombre = modelAlumno.SegundoNombre;
            model.PrimerApellido = modelAlumno.PrimerApellido;
            model.SegundoApellido = modelAlumno.SegundoApellido;
            model.Sexo = modelAlumno.Sexo;
            model.FechaDeNacimiento = modelAlumno.FechaDeNacimiento;
            model.IdPeriodoEscolar = modelAlumno.IdPeriodoEscolar;
            model.IdGradoEscolar = modelAlumno.IdGradoEscolar;
            model.Telefono = modelAlumno.Telefono;
            model.TelefonoAdicional = modelAlumno.TelefonoAdicional;
            Estado modelEstado = new Estado();
            modelEstado = await estado.GetByName("Solicitado");
            model.IdEstado = modelEstado.Id;

            return model;
        }

        public async Task<SolicitudCupo> GetByAlumno(Guid id)
        {
            return await service.SearchByIdAlumno(id);
        }
    }
}
