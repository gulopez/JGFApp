using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class PreInscripcionBussiness
    {
        private static Models.PreInscripcion preInscripcion;
        private static List<Models.PreInscripcion> preInscripciones;
        private static Models.Estado modelEstado;
        private static EstadoBussiness estado = new EstadoBussiness();
        private static Services.PreInscripcionServices service = new Services.PreInscripcionServices();

        public async Task<bool> Save(Guid id, string comentario, Guid idGrado, Guid idPeriodo, Guid idUsuario, Guid idRepresentante)
        {
            preInscripcion = new Models.PreInscripcion();
            preInscripcion.Id = Guid.NewGuid();
            preInscripcion.Comentarios = comentario;
            preInscripcion.FechaPreInscripcion = DateTime.Now;
            preInscripcion.Actualizado = DateTime.Now;
            preInscripcion.IdAlumno = id;
            preInscripcion.IdPeriodoEscolar = idPeriodo;
            preInscripcion.IdGradoEscolar = idGrado;
            preInscripcion.IdUsuario = idUsuario;
            preInscripcion.IdRepresentante = idRepresentante;
            modelEstado = new Models.Estado();
            modelEstado = await estado.GetByName("Nuevo");
            preInscripcion.IdEstado = modelEstado.Id;
            preInscripcion.Alumno = null;
            preInscripcion.PeriodoEscolar = null;
            preInscripcion.GradoEscolar = null;
            preInscripcion.Usuario = null;
            preInscripcion.Representante = null;

            return await service.Save(preInscripcion);
        }

        public async Task<bool> Update(Guid id, Guid idEstado)
        {
            preInscripcion = await service.SearchById(id);
            preInscripcion.Actualizado = DateTime.Now;
            preInscripcion.IdEstado = idEstado;
            preInscripcion.Alumno = null;
            preInscripcion.PeriodoEscolar = null;
            preInscripcion.GradoEscolar = null;
            preInscripcion.Usuario = null;
            preInscripcion.Representante = null;

            return await service.Update(preInscripcion);
        }

        public async Task<PreInscripcion> GetById(Guid id)
        {
            return await service.SearchById(id);
        }
    }
}
