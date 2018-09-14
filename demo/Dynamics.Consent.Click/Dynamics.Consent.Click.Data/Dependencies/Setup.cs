using Dynamics.Consent.Click.Data.Mapping;
using Dynamics.Consent.Click.Data.ModelRepository;
using Dynamics.Consent.Click.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Consent.Click.Data.Dependencies
{
    public class Setup
    {
        public static void Initialize(IUnityContainer container)
        {
            container.RegisterType<IEntityRepository, EntityRepository>();

            container.RegisterType<IEntityMapper<SentEmail>, SentEmailMapper>();
        }
    }
}
