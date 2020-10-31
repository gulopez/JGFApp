using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Bussiness.Interfaces
{
    public interface ICommons<T>
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task<List<T>> GetByKeyword(string keyword);
        Task<Boolean> SaveEntity(T model);
        Task<Boolean> UpdateEntity(T model);
        Task<Boolean> DeleteEntity(Guid id);
    }
}
