using Bocasay.Data.SqlServer.Etities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Configurations
{
	public class UserRoleMapConfiguration : IEntityTypeConfiguration<UserRoleMap>
	{
		public void Configure(EntityTypeBuilder<UserRoleMap> builder)
		{
			builder.ToTable("UserRoleMaps");

			builder.HasOne(t => t.Role).WithMany(ro => ro.UserRoleMaps).
				HasForeignKey(ro => ro.RoleID);
			builder.HasOne(t => t.User).WithMany(us => us.UserRoleMaps)
				.HasForeignKey(us => us.UserID);
		}
	}
}
