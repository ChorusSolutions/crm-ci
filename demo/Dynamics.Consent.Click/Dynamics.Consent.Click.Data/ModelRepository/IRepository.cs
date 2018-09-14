using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Consent.Click.Data.ModelRepository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(QueryExpression query);
        T Get(Guid id);
        Guid Upsert(T item);

    }
}
