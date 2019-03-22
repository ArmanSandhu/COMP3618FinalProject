using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDbDotNetDomain
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        IRepository<T> Repository<T>() where T : class;
    }
}
