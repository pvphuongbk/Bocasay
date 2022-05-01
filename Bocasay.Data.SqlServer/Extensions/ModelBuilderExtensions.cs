using Bocasay.Common.Enums;
using Bocasay.Data.SqlServer.Enums;
using Bocasay.Data.SqlServer.Etities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Extensions
{
	public static class ModelBuilderExtensions
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				new User() { ID = Guid.Parse("6f8fad5b-d9cb-469f-a165-70867728950e"), FullName = "David Tommy", Email = "Davidtommy.bocasy.com", Address = "1A - HHT st", CreatedDate = DateTime.Parse("11/21/2021"), ModifiedDate = DateTime.Parse("11/21/2021") },
				new User() { ID = Guid.Parse("6f8fad5b-d9cb-469f-a165-70867728ab56"), FullName = "Sakca Phonel", Email = "Sakcaphonel.bocasy.com", Address = "13B - HHT st", CreatedDate = DateTime.Parse("11/21/2021"), ModifiedDate = DateTime.Parse("11/21/2021") }
				);
			modelBuilder.Entity<Role>().HasData(
				new Role() { ID = Guid.Parse("6f8fad5b-d9cb-469f-a165-708677289506"), RoleCode = "Admin", RoleCategory = RoleCategory.Admin, Description = "Administrator", CreatedDate = DateTime.Parse("11/21/2021"), ModifiedDate = DateTime.Parse("11/21/2021") },
				new Role() { ID = Guid.Parse("6a4fad5b-d9cb-469f-a165-708677289506"), RoleCode = "Viewer", RoleCategory = RoleCategory.Viewer, Description = "Viewer", CreatedDate = DateTime.Parse("11/21/2021"), ModifiedDate = DateTime.Parse("11/21/2021") }
				);
			modelBuilder.Entity<UserRoleMap>().HasData(
				new UserRoleMap() { ID = Guid.Parse("688fad5b-d9cb-469f-a165-708677289506"), UserID = Guid.Parse("6f8fad5b-d9cb-469f-a165-70867728950e"), RoleID = Guid.Parse("6f8fad5b-d9cb-469f-a165-708677289506") , CreatedDate = DateTime.Parse("11/21/2021"), ModifiedDate = DateTime.Parse("11/21/2021") },
				new UserRoleMap() { ID = Guid.Parse("600fad5b-d9cb-469f-a165-708677289506"), UserID = Guid.Parse("6f8fad5b-d9cb-469f-a165-70867728ab56"), RoleID = Guid.Parse("6a4fad5b-d9cb-469f-a165-708677289506"), CreatedDate = DateTime.Parse("11/21/2021"), ModifiedDate = DateTime.Parse("11/21/2021") }
				);
		}
	}
}
