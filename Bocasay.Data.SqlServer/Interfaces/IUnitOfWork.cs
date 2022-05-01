using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Interfaces
{
    public interface IUnitOfWork<D> : IDisposable where D : IDBContext
    {
        void BeginTransaction();
        /// <summary>
        /// Call save change from db context
        /// </summary>
        int Commit(bool isTrackChanged = true);
        //Task<int> CommitAsyn(bool acceptAllChangesOnSuccess, System.Threading.CancellationToken cancellationToken);
        Task<int> CommitAsync(bool isTrackChanged = true);

        void RollBack();
    }
}
