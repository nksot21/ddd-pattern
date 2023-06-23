using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.Domain.IRepository
{
    public interface IRepositoryReadonly<T> where T : class, IBaseEntity
    {
        public IQueryable<T> GetAll();
        public Task Create(T entities);

        public IQueryable<T> GetByQuery(Expression<Func<T, bool>> query);

        public IQueryable<T> GetByQueryPaged(Expression<Func<T, bool>> query, int pageSize = 0, int pageNumber = 0);
    }
}
