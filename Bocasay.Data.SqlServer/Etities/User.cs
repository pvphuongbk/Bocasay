using Bocasay.Data.SqlServer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Etities
{
	public class User : BaseEntity
	{
		public User()
		{
			IsDeleted = false;
		}
		public string FullName { get; set; }

		public string Email { get; set; }

		public string Company { get; set; }

		public string Address { get; set; }

		public ICollection<UserRoleMap> UserRoleMaps { get; set; }
	}
}
