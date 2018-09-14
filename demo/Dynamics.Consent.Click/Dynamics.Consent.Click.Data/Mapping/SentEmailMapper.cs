using System.Collections.Generic;
using Dynamics.Consent.Click.Data.Mapping;
using Microsoft.Xrm.Sdk;
using Chorus.Dynamics.CrmMappers;
using Dynamics.Consent.Click.Models;
using Dynamics.Consent.Click.Models.Constants;

namespace Dynamics.Consent.Click.Data.Dependencies
{
    public class SentEmailMapper : IEntityMapper<SentEmail>
    {
        public string LogicalName => SentEmailAttributes.EntityName;

        public IEnumerable<SentEmail> Map(IEnumerable<Entity> entities)
        {
            return CrmMapper.Map<SentEmail>(entities);
        }

        public Entity Map(SentEmail item)
        {
            throw new System.NotImplementedException();
        }

        public SentEmail MapSingle(IEnumerable<Entity> entities)
        {
            return CrmMapper.MapSingle<SentEmail>(entities);
        }
    }
}