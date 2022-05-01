using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Base
{
    public interface IBaseEntity
    {
        Guid ID { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreatedDate { get; set; }
        Guid? CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        Guid? ModifiedBy { get; set; }
    }
}
