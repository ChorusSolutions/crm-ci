using Dynamics.Consent.Click.Data.Mapping;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dynamics.Consent.Click.Data.ModelRepository
{
    public class BasicModelRepository<T> : IRepository<T> where T : new()
    {
        public IEntityRepository Repository { get; set; }
        public IEntityMapper<T> Mapper { get; set; }

        protected string Name { get; }

        public BasicModelRepository(IEntityMapper<T> mapper, IEntityRepository repository)
        {
            Mapper = mapper;
            Repository = repository;
            Name = Mapper.LogicalName;
        }

        public virtual T Get(Guid id)
        {
            return Mapper.Map(new Entity[] { Repository.Get(Name, id) })
                .SingleOrDefault();
        }

        public virtual Guid Upsert(T item)
        {
            return Repository.Upsert(Mapper.Map(item));
        }

        public IEnumerable<T> GetAll(QueryExpression query)
        {
            query.EntityName = Name;
            var collection = Repository.Query(query);

            return Mapper.Map(collection);
        }

    }
}
