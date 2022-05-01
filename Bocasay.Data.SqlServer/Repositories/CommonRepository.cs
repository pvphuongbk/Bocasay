using Bocasay.Data.SqlServer.EF;
using Bocasay.Data.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Repositories
{
    public class CommonRepository<T> : Repository<CommonDBContext, T>, ICommonRepository<T> where T : class
    {
        public CommonRepository(CommonDBContext context) : base(context)
        {

        }
    }
}
