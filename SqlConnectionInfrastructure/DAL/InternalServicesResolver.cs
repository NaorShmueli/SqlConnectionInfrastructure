using AdoTemplate.Abstraction;
using DAL.DB;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InternalServicesResolver
    {
        public void RegisterInternalServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<AdoRepository<Person>, PersonAdoRepository>();
        }
    }
}
