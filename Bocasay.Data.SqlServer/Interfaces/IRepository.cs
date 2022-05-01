using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Interfaces
{
    public interface IRepository<T> : IQueryRepository<T>, ICommandRepository<T> where T : class
    {

    }
}
