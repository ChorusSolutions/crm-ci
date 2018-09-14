using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Consent.Click.Data.Mapping
{
    public interface IEntityMapper<T>
    {
        IEnumerable<T> Map(IEnumerable<Entity> entities);
        T MapSingle(IEnumerable<Entity> entities);
        Entity Map(T item);
        string LogicalName { get; }
    }
}
