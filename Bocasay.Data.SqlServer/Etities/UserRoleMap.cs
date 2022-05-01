using Bocasay.Data.SqlServer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Etities
{
	public class UserRoleMap : BaseEntity
	{
		public UserRoleMap()
		{
			IsDeleted = false;
		}
		public Guid UserID { get; set; }
		public Guid RoleID { get; set; }
		public virtual User User { get; set; }
		public virtual Role Role { get; set; }
	}
}
