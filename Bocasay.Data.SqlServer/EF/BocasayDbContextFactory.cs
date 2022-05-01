using Bocasay.Data.SqlServer.Configurations;
using Bocasay.Data.SqlServer.Etities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.EF
{
	public class BocasayDbContextFactory : IDesignTimeDbContextFactory<CommonDBContext>
	{
		public CommonDBContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath((Directory.GetCurrentDirectory()))
				.AddJsonFile("appsettings.json")
				.Build();

			var connectionString = configuration.GetConnectionString("BocasayDb");

			var optionsBuilder = new DbContextOptionsBuilder<CommonDBContext>();
			optionsBuilder.UseSqlServer(connectionString);
			return new CommonDBContext(optionsBuilder.Options);
		}
	}
}
