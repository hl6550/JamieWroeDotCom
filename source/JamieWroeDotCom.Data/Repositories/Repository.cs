using System.Data;
using System.Linq;
using JamieWroeDotCom.Data.DataProviders;

namespace JamieWroeDotCom.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IUniqueEntity
    {
        private readonly IDataProvider dataProvider;
        public Repository(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public IQueryable<T> GetAll()
        {
            return dataProvider.Query<T>();
        }

        public T GetById(int id)
        {
            return dataProvider.Query<T>(entity => entity.Id == id)
                               .Single();
        }

        public void Add(T entity)
        {
            var statefulEntity = dataProvider.GetStatefulEntity(entity);

            if (statefulEntity.State == EntityState.Detached)
            {
                statefulEntity.State = EntityState.Added;
            }
            else
            {
                dataProvider.Add(entity);
            }
        }

        public void Update(T entity)
        {
            var statefulEntity = dataProvider.GetStatefulEntity(entity);

            if (statefulEntity.State == EntityState.Detached)
            {
                dataProvider.Attach(entity);
            }

            statefulEntity.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var statefulEntity = dataProvider.GetStatefulEntity(entity);

            if (statefulEntity.State == EntityState.Detached)
            {
                dataProvider.Attach(entity);
                dataProvider.Remove(entity);
            }

            statefulEntity.State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            Delete(entity);
        }
    }
}