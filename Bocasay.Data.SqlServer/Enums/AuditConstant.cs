using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Enums
{
    public class AuditConstant
    {
        public enum AuditModule
        {
            UnKnown = 0,
            Asset = 1,
            Inspection = 2,
            Monitoring = 3,
            TaskManager = 4,
            Incident = 5,
            Assessment = 6,
        }


        public enum AuditState
        {
            Detached = 0,
            Unchanged = 1,
            [Description("Delete")]
            Deleted = 2,
            [Description("Edit")]
            Modified = 3,
            [Description("Add")]
            Added = 4
        }
    }
}
