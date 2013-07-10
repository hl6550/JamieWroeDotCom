using System;
using System.Linq;
using JamieWroeDotCom.Data.Repositories;

namespace JamieWroeDotCom.Data
{
    public interface IDataProvider : IDisposable
    {
        void Commit();
        void Rollback();
        void Add<T>(T entity) where T : class, IUniqueEntity;
        void Attach<T>(T entity) where T : class, IUniqueEntity;
        void Remove<T>(T entity) where T : class, IUniqueEntity;
        IQueryable<T> Query<T>() where T : class, IUniqueEntity;
        IQueryable<T> Query<T>(Predicate<T> query) where T : class, IUniqueEntity;
        IStatefulEntity<T> GetStatefulEntity<T>(T entity) where T : class, IUniqueEntity;
    }
}