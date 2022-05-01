using Bocasay.Common.Enums;
using Bocasay.Data.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.Dto.User
{
	public class CreateUserDto
	{
		public string FullName { get; set; }

		public string Email { get; set; }

		public string Company { get; set; }

		public List<RoleCategory> RoleCategorys { get; set; }

		public string Address { get; set; }
	}
}
