using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace JamieWroeDotCom.Data.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> DbSet { get; set; }
        private DbContext Context { get; set; }

        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            Context = context;
            DbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public void Detach(T entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }
    }
}