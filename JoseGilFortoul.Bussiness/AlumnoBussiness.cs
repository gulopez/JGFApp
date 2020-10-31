using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class AlumnoBussiness : ICommons<Alumno>
    {
        private static Alumno alumno;
        private static List<Alumno> alumnos;
        private static EstadoProvincia estadoProvincia;
        private static ProvinciaEstadoBussiness provinciaEstado = new ProvinciaEstadoBussiness();
        private static RepresentanteBussiness representante = new RepresentanteBussiness();
        private static Services.AlumnoServices service = new Services.AlumnoServices();

        public async Task<bool> DeleteEntity(Guid id)
        {
            return await service.Delete(id);
        }

        public async Task<List<Alumno>> GetAll()
        {
            return await service.SearchAll();
        }

        public async Task<Models.Alumno> GetById(Guid id)
        {
            return await service.SearchById(id);
        }

        public async Task<List<Models.Alumno>> GetByKeyword(string keyword)
        {
            return await service.SearchByKeyword(keyword);
        }

        public async Task<bool> SaveEntity(Alumno model)
        {
            return await service.Save(model);
        }

        public async Task<bool> UpdateEntity(Alumno model)
        {
            return await service.Update(model);
        }

        public async Task<List<Alumno>> GetByRepresentative(Guid id)
        {
            return await service.SearchByRepresentative(id);
        }

        public async Task<Alumno> MatchModel(Alumno model, int tipoRepresentante, Representante modelRepresentante, int representanteLegal)
        {
            //Modelamos los datos para el Alumno
            model.Id = Guid.NewGuid();
            model.Direccion.Id = Guid.NewGuid();
            model.IdDireccion = model.Direccion.Id;
            estadoProvincia = new EstadoProvincia();
            estadoProvincia = await provinciaEstado.GetByName(model.Direccion.EstadoProvincia.Nombre);
            model.Direccion.IdEstadoProvincia = estadoProvincia.Id;
            model.Direccion.EstadoProvincia = null;
            model.DatosFamiliares.Id = Guid.NewGuid();
            model.IdDatosFamiliares = model.DatosFamiliares.Id;
            model.DatosMedicos.Id = Guid.NewGuid();
            model.IdDatosMedicos = model.DatosMedicos.Id;
            model.PeriodoEscolar = null;
            model.GradoEscolar = null;

            if (tipoRepresentante == 1)
            {
                //Modelamos los datos para el Padre
                model.IdPadre = modelRepresentante.Id;
                modelRepresentante.Parentesco = "Padre";
                model.Padre = null;

                //Modelamos los datos para la Madre
                model.Madre.Id = Guid.NewGuid();
                model.IdMadre = model.Madre.Id;
                model.Madre.Parentesco = "Madre";
                model.Madre.Direccion.Id = Guid.NewGuid();
                model.Madre.IdDireccion = model.Madre.Direccion.Id;
                estadoProvincia = new EstadoProvincia();
                estadoProvincia = await provinciaEstado.GetByName(model.Madre.Direccion.EstadoProvincia.Nombre);
                model.Madre.Direccion.IdEstadoProvincia = estadoProvincia.Id;
                model.Madre.Direccion.EstadoProvincia = null;
            }
            else if (tipoRepresentante == 2)
            {
                //Modelamos los datos para el Padre
                model.Padre.Id = Guid.NewGuid();
                model.IdPadre = model.Padre.Id;
                model.Padre.Parentesco = "Padre";
                model.Padre.Direccion.Id = Guid.NewGuid();
                model.Padre.IdDireccion = model.Padre.Direccion.Id;
                estadoProvincia = new EstadoProvincia();
                estadoProvincia = await provinciaEstado.GetByName(model.Padre.Direccion.EstadoProvincia.Nombre);
                model.Padre.Direccion.IdEstadoProvincia = estadoProvincia.Id;
                model.Padre.Direccion.EstadoProvincia = null;

                //Modelamos los datos para la Madre
                model.IdMadre = modelRepresentante.Id;
                modelRepresentante.Parentesco = "Madre";
                model.Madre = null;
            }
            else
            {
                //Modelamos los datos para el Padre
                model.Padre.Id = Guid.NewGuid();
                model.IdPadre = model.Padre.Id;
                model.Padre.Parentesco = "Padre";
                model.Padre.Direccion.Id = Guid.NewGuid();
                model.Padre.IdDireccion = model.Padre.Direccion.Id;
                estadoProvincia = new EstadoProvincia();
                estadoProvincia = await provinciaEstado.GetByName(model.Padre.Direccion.EstadoProvincia.Nombre);
                model.Padre.Direccion.IdEstadoProvincia = estadoProvincia.Id;
                model.Padre.Direccion.EstadoProvincia = null;

                //Modelamos los datos para la Madre
                model.Madre.Id = Guid.NewGuid();
                model.IdMadre = model.Madre.Id;
                model.Madre.Parentesco = "Madre";
                model.Madre.Direccion.Id = Guid.NewGuid();
                model.Madre.IdDireccion = model.Madre.Direccion.Id;
                estadoProvincia = new EstadoProvincia();
                estadoProvincia = await provinciaEstado.GetByName(model.Madre.Direccion.EstadoProvincia.Nombre);
                model.Madre.Direccion.IdEstadoProvincia = estadoProvincia.Id;
                model.Madre.Direccion.EstadoProvincia = null;

                //Modelamos los datos del Representante
                model.IdRepresentante = modelRepresentante.Id;
                modelRepresentante.Parentesco = "Representante";
                model.Representante = null;
            }

            if (representanteLegal == 1)
            {
                if (model.Padre == null)
                {
                    //Modelamos los datos del Representante
                    model.IdRepresentante = modelRepresentante.Id;
                }
                else
                {
                    //Modelamos los datos del Representante
                    model.IdRepresentante = model.Padre.Id;
                }
                model.Representante = null;
            }
            else if (representanteLegal == 2)
            {
                if (model.Madre == null)
                {
                    //Modelamos los datos del Representante
                    model.IdRepresentante = modelRepresentante.Id;
                }
                else
                {
                    //Modelamos los datos del Representante
                    model.IdRepresentante = model.Madre.Id;
                }
                model.Representante = null;
            }
            else
            {
                //Modelamos los datos del Representante
                model.Representante.Id = Guid.NewGuid();
                model.IdRepresentante = model.Representante.Id;
                model.Representante.Parentesco = "Representante";
                model.Representante.Direccion.Id = Guid.NewGuid();
                model.Representante.IdDireccion = model.Representante.Direccion.Id;
                estadoProvincia = new EstadoProvincia();
                estadoProvincia = await provinciaEstado.GetByName(model.Representante.Direccion.EstadoProvincia.Nombre);
                model.Representante.Direccion.IdEstadoProvincia = estadoProvincia.Id;
                model.Representante.Direccion.EstadoProvincia = null;
            }

            await representante.UpdateEntity(modelRepresentante);

            return model;
        }

        public async Task<List<Alumno>> GetByPreInscription()
        {
            return await service.SearchByPreInscription();
        }

        public async Task<bool> ExistsEntity(string cardId)
        {
            return await service.SearchIfExists(cardId);
        }
    }
}
