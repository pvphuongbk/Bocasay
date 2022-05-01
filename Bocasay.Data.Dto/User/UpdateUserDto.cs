using Bocasay.Common.Enums;
using System;
using System.Collections.Generic;

namespace Bocasay.Data.Dto.User
{
	public class UpdateUserDto
	{
		public string FullName { get; set; }

		public string Email { get; set; }

		public string Company { get; set; }

		public List<RoleCategory> RoleCategorys { get; set; }

		public string Address { get; set; }
	}
}
