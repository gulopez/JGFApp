using JoseGilFortoul.Bussiness.Interfaces;
using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness
{
    public class UsuarioBussiness : ICommons<Models.Usuario>
    {
        private static Models.Usuario usuario;
        private static List<Models.Usuario> usuarios;
        private static Services.UsuarioServices service = new Services.UsuarioServices();
        private static Hashing.Hashing hashing = new Hashing.Hashing();

        public async Task<Models.Usuario> DoLogin(string email, string pass)
        {
            return await service.Login(email, pass);
        }

        public async Task<bool> Register(string nombre, string apellido, string mail, string cardId, string pass)
        {
            return await service.Register(nombre, apellido, mail, cardId, pass);
        }

        public async Task<bool> Recover(string email)
        {
            return await service.Recover(email);
        }

        public async Task<Models.Usuario> GetById(string id)
        {
            return await service.SearchEntity(id);
        }

        public Task<List<Models.Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Models.Usuario>> GetByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.Usuario> GetByEmail(string email)
        {
            return await service.SearchEntityByEmail(email);
        }

        public Task<bool> SaveEntity(Models.Usuario model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(Models.Usuario model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ChangePassword(Models.Usuario model, string pass)
        {
            return await service.ChangePassword(model, pass);
        }

        public Task<Usuario> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetById(Guid id)
        {
            return await service.SearchEntity(id);
        }

        public string GetHashingPass(string pass)
        {
            return service.EncryptedPassWord(pass);
        }
    }
}
