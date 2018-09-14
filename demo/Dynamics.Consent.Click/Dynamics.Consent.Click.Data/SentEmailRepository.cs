using Dynamics.Consent.Click.Data.ModelRepository;
using Dynamics.Consent.Click.Models;
using System;
using System.Linq;
using Dynamics.Consent.Click.Data.Mapping;
using Dynamics.Consent.Click.Data.Queries;
using Microsoft.Xrm.Sdk.Query;

namespace Dynamics.Consent.Click.Data
{
    public class SentEmailRepository : BasicModelRepository<SentEmail>
    {
        private IEntityRepository Repository { get; set; }
        IEntityMapper<SentEmail> Mapper { get; set; }

        public SentEmailRepository(IEntityMapper<SentEmail> mapper, IEntityRepository repository) : base(mapper, repository)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public override SentEmail Get(Guid id)
        {
            var list = Repository.Query(new SentEmailQuery(id).GetEntityQuery());

            if (list.Any())
            {
                var mappedValues = Mapper.MapSingle(list);
                return mappedValues;
            }


            return null;
        }
    }
}
