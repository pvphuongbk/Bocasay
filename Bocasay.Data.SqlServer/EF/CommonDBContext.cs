using Bocasay.Data.SqlServer.Configurations;
using Bocasay.Data.SqlServer.Etities;
using Bocasay.Data.SqlServer.Extensions;
using Bocasay.Data.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.EF
{
	public class CommonDBContext : PDataContext
	{
		public CommonDBContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder moduleBuilder)
		{
			moduleBuilder.ApplyConfiguration(new UserConfiguration());
			moduleBuilder.ApplyConfiguration(new RoleConfiguration());
			moduleBuilder.ApplyConfiguration(new UserRoleMapConfiguration());

			// Seeding data
			//moduleBuilder.Seed();
			//base.OnModelCreating(moduleBuilder);
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRoleMap> UserRoleMaps { get; set; }
	}
}
