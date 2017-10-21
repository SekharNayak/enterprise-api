using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.api.repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T GetById(int Id);
        void Post(T entity);
        void Put(int id, T entity);
        void Delete(int id);
    }
}
