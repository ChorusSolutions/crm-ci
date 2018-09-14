using Chorus.Dynamics.ServiceStore;
using Dynamics.UpdateIsolator;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Consent.Click.Data.ModelRepository
{
    public class EntityRepository : IEntityRepository
    {

        public Entity Get(string entityName, Guid entityId)
        {
            return ServiceStore<IOrganizationService>.Singleton.Locate().Retrieve(entityName, entityId, new ColumnSet(true));
        }

        public IEnumerable<Entity> Query(QueryExpression query)
        {
            return ServiceStore<IOrganizationService>.Singleton.Locate().RetrieveMultiple(query).Entities;
        }

        public Guid Upsert(Entity item)
        {
            EntityUpdateIsolator updateIsolator = new EntityUpdateIsolator();

            var currentState = Get(item.LogicalName, item.Id);
            var isolatedUpdates = updateIsolator.IsolateUpdates(item, currentState);

            if (isolatedUpdates.Attributes.Count > 0)
            {
                ServiceStore<IOrganizationService>.Singleton.Locate().Update(isolatedUpdates);
            }

            return item.Id;
        }
        
    }
}
