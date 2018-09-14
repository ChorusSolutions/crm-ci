using Microsoft.Xrm.Sdk;
using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Consent.Click.Plugins
{
    [CrmPluginRegistration("Create", "account",
    StageEnum.PreValidation, ExecutionModeEnum.Synchronous,
    "name,address1_line1", "Create Step", 1, IsolationModeEnum.Sandbox,
    Description = "Description",
    UnSecureConfiguration = "Some config")]
    public class Class1 : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context from the service provider.
            IPluginExecutionContext context = (Microsoft.Xrm.Sdk.IPluginExecutionContext)
                serviceProvider.GetService(typeof(Microsoft.Xrm.Sdk.IPluginExecutionContext));

            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            try
            {
                //TODO: Code goes here
            }

            catch (FaultException<OrganizationServiceFault> e)
            {
                throw new InvalidPluginExecutionException("Error in Plugin" + e.ToString());
            }
        }
    }
}
