using JamieWroeDotCom.Data.DataProviders;
using JamieWroeDotCom.Data.Repositories;
using Ninject;

namespace JamieWroeDotCom.UI.App_Start
{
    public static class NinjectHelper
    {
        public static void ConfigureNinject()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataProvider>().To<EntityFrameworkDataProvider>();
            kernel.Bind(typeof (IRepository<>)).To(typeof (Repository<>));
        }
    }
}