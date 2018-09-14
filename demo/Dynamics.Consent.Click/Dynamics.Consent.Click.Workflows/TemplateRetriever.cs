using Chorus.Dynamics.ServiceStore;
using Dynamics.Consent.Click.Services;
using Microsoft.Practices.Unity;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Consent.Click.Workflows
{
    
    [CrmPluginRegistration(
    "Email Template Retriever", "d44396da-71b9-493a-8a0d-712af85a0059","","CHORUS Consent Click Adapter",IsolationModeEnum.Sandbox
    )]
    public class TemplateRetriever : CodeActivity
    {
        [Input("Sent Email")]
        [ReferenceTarget("cdi_sentemail")]
        public InArgument<EntityReference> SentEmail { get; set; }

        [Output("Email Template")]
        [ReferenceTarget("cdi_emailtemplate")]
        public OutArgument<EntityReference> EmailTemplate { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            // Create the tracing service
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            if (tracingService == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve tracing service.");
            }

            tracingService.Trace("Entered Execute(), Activity Instance Id: {0}, Workflow Instance Id: {1}",
                        executionContext.ActivityInstanceId,
                        executionContext.WorkflowInstanceId);

            // Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();

            if (context == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve workflow context.");
            }

            tracingService.Trace("Execute(), Correlation Id: {0}, Initiating User: {1}",
                            context.CorrelationId,
                            context.InitiatingUserId);

            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            try
            {
                ServiceStore<IOrganizationService>.Singleton.Store(service);

                var container = new UnityContainer();
                Services.Dependencies.Setup.Initialize(container);
                
                var ServiceMethod = container.Resolve<ClickDimensionsEmailRetriever>();
                var emailTemplateId = ServiceMethod.GetTemplateId(this.SentEmail.Get<EntityReference>(executionContext).Id);

                if (emailTemplateId.HasValue)
                {
                    this.EmailTemplate.Set(executionContext, new EntityReference("cdi_emailtemplate", emailTemplateId.Value));
                }                
            }

            catch (FaultException<OrganizationServiceFault> e)
            {
                throw new InvalidPluginExecutionException("Error in Workflow Activity " + e.ToString());
            }

        }
    }
}