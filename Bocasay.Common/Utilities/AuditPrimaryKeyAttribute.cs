using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Common.Utilities
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class AuditPrimaryKeyAttribute : Attribute
    {
    }
}
