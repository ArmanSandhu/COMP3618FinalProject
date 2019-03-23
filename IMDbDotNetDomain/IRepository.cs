using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IMDbDotNetDomain
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T Read(Expression<Func<T, bool>> predicate);
        IQueryable<T> Reads(string predicate);
        IQueryable<T> Reads();
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
