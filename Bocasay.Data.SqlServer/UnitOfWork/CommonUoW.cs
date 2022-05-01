using Bocasay.Data.SqlServer.EF;
using Bocasay.Data.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.UnitOfWork
{
    public class CommonUoW : UnitOfWork<CommonDBContext>, ICommonUoW
    {
        public CommonUoW(CommonDBContext context) : base(context)
        {
        }

    }
}
