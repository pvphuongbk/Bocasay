using Bocasay.Data.Dto.Base;
using Bocasay.Data.SqlServer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.Redis.BaseDatabase
{
    public class BaseDtoCompare<T> : IEqualityComparer<T> where T : BaseDto
    {
        public bool Equals(T x, T y)
        {
            if (x.ID == y.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(T obj)
        {
            return obj.ID.GetHashCode();
        }
    }
}
