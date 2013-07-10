using System.Linq;

namespace JamieWroeDotCom.Data.Repositories
{
    internal interface IRepository<T>  where T : IUniqueEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}