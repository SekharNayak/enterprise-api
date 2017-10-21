using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.api.repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Post(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Put(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
