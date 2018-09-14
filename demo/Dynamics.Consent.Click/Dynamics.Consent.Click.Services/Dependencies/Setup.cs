using Dynamics.Consent.Click.Data;
using Dynamics.Consent.Click.Data.ModelRepository;
using Dynamics.Consent.Click.Models;
using Microsoft.Practices.Unity;

namespace Dynamics.Consent.Click.Services.Dependencies
{
    public class Setup
    {
        public static void Initialize(IUnityContainer container)
        {
            container.RegisterType<IRepository<SentEmail>, SentEmailRepository>();

            Logic.Dependencies.Setup.Initialize(container);
        }
    }
}
