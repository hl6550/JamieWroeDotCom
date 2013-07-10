using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using JamieWroeDotCom.Data.Repositories;

namespace JamieWroeDotCom.Data.DataProviders
{
    internal class EntityFrameworkDataProvider : IDataProvider
    {
        private readonly DbContext context;

        public EntityFrameworkDataProvider(DbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Rollback()
        {
        }

        public void Add<T>(T entity) where T : class, IUniqueEntity
        {
            context.Set<T>()
                   .Add(entity);
        }

        public void Attach<T>(T entity) where T : class, IUniqueEntity
        {
            context.Set<T>()
                   .Attach(entity);
        }

        public void Remove<T>(T entity) where T : class, IUniqueEntity
        {
            context.Set<T>()
                   .Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : class, IUniqueEntity
        {
            return context.Set<T>();
        }

        public IQueryable<T> Query<T>(Predicate<T> query) where T : class, IUniqueEntity
        {
            return context.Set<T>()
                          .Where(entity => query(entity));
        }

        public IStatefulEntity<T> GetStatefulEntity<T>(T entity) where T : class
        {
            return new StatefulEntity<T>
                   {
                       Entity = entity,
                       State = context.Entry(entity).State
                   };
        }

        private class StatefulEntity<T> : IStatefulEntity<T> where T : class
        {
            public T Entity { get; internal set; }
            public EntityState State { get; set; }
        }
    }
}