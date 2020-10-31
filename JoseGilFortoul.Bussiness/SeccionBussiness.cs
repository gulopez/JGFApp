using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class SeccionBussiness : ICommons<Seccion>
    {
        private static Seccion seccion;
        private static List<Seccion> secciones;
        private static Services.SeccionServices service = new Services.SeccionServices();

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Seccion>> GetAll()
        {
            return await service.SearchAll();
        }

        public Task<Seccion> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Seccion>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntity(Seccion model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(Seccion model)
        {
            throw new NotImplementedException();
        }
    }
}
