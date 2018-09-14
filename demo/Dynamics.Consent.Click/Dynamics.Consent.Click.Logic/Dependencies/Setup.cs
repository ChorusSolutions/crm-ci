using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Consent.Click.Logic.Dependencies
{
    public class Setup
    {
        public static void Initialize(IUnityContainer container)
        {
          Data.Dependencies.Setup.Initialize(container);
        }
    }
}
