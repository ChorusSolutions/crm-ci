using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Consent.Click.Data.ModelRepository
{
    public interface IEntityRepository
    {
        Entity Get(string entityName, Guid entityId);

        Guid Upsert(Entity item);

        IEnumerable<Entity> Query(QueryExpression query);


    }
}