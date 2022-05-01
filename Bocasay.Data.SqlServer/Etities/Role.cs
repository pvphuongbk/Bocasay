using Bocasay.Common.Enums;
using Bocasay.Data.SqlServer.Base;
using Bocasay.Data.SqlServer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Etities
{
	public class Role : BaseEntity
	{
		public Role()
		{
			IsDeleted = false;
		}
		public string RoleCode { get; set; }

		public string Description { get; set; }

		public RoleCategory RoleCategory { get; set; }

		public ICollection<UserRoleMap> UserRoleMaps { get; set; }
	}
}
