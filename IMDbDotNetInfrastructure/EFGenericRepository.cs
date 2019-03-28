using IMDbDotNetDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IMDbDotNetInfrastructure
{
    public class EFGenericRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
    {
        private DbContext Context { get; set; }
        public EFGenericRepository(DbContext inContext)
        {
            Context = inContext;
        }
        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public TEntity Read(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }
        public IQueryable<TEntity> Reads(string predicate, int startindex, int pagesize)
        {
            
            return Context.Set<TEntity>().SqlQuery("Select * from [IMDb].[movie].[titlebasics] where tconst LIKE @p0", "%" + predicate + "%").Skip(startindex-1).Take(pagesize).AsQueryable();
        }
        public IQueryable<TEntity> Reads(int startindex, int pagesize)
        {
            return Context.Set<TEntity>().SqlQuery("Select * from [IMDb].[movie].[titlebasics]").Skip(startindex-1).Take(pagesize).AsQueryable();
        }
        public void Update(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
        public void Update(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties)
        {
            Context.Configuration.ValidateOnSaveEnabled = false;

            Context.Entry<TEntity>(entity).State = EntityState.Unchanged;

            if (updateProperties != null)
            {
                foreach (var property in updateProperties)
                {
                    Context.Entry<TEntity>(entity).Property(property).IsModified = true;
                }
            }
        }
        public void Delete(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
            if (Context.Configuration.ValidateOnSaveEnabled == false)
            {
                Context.Configuration.ValidateOnSaveEnabled = true;
            }
        }
    }
}
