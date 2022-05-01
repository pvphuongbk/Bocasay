using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Interfaces
{
    public interface IDBContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, System.Threading.CancellationToken cancellationToken);
    }
}
