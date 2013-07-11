using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamieWroeDotCom.Data.DataProviders;
using JamieWroeDotCom.Data.Repositories;
using Ninject;

namespace JamieWroeDotCom.Data
{
    class NinjectBindings
    {
        public NinjectBindings()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataProvider>().To<EntityFrameworkDataProvider>();
            
        }
    }
}
