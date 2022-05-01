using Bocasay.Core.Bus;
using Bocasay.Data.Dto.User;
using Bocasay.Data.JsonFile.Base;
using Bocasay.Data.JsonFile.User;
using Bocasay.Data.Redis.Implememt;
using Bocasay.Data.Redis.Interface;
using Bocasay.Data.SqlServer.EF;
using Bocasay.Data.SqlServer.Etities;
using Bocasay.Data.SqlServer.Interfaces;
using Bocasay.Data.SqlServer.Repositories;
using Bocasay.Data.SqlServer.UnitOfWork;
using Bocasay.Domain.Commands.UserCommands;
using Bocasay.Service.Configurations;
using Bocasay.Service.Implememt;
using Bocasay.Service.Interface;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System.Reflection;

namespace Bocasay.Api
{
	public class Startup
	{
		private readonly IConfiguration _config;
		public Startup(IConfiguration configuration)
		{
			_config = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bocasay.Api", Version = "v1" });
			});

			services.AddCors(option =>
			{
				option.AddDefaultPolicy(builder =>
				{
					builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
				});
			});


			#region Dependency
			services.AddSingleton<IUserJsonRepository, UserJsonRepository>();
			//services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			//	.AddMicrosoftIdentityWebApi(_config, "AzureAd");
			services.AddDbContext<CommonDBContext>(options =>

				options.UseSqlServer(_config.GetConnectionString("BocasayDb")), ServiceLifetime.Scoped
			);

			// Auto maper
			services.AddCommonServices();


			services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));
			services.AddScoped<ICommonUoW,CommonUoW>();

			// Mediator
			services.AddMediatR(typeof(CreatedUserCommand).GetTypeInfo().Assembly);
			services.AddScoped<IMediatorHandler, InMemoryBus>();

			// Service
			services.AddScoped<IUserService, UserService>();

			// Redis Repository
			services.AddScoped<IUserRepositoryRedis, UserRepositoryRedis>();

			// Redis
			string redisConnection = _config.GetSection("MyConfigs")["RedisConnection"];
			services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection));
			services.AddSingleton<IDatabase>(sp =>
			{
				var con = sp.GetService<IConnectionMultiplexer>();
				return con.GetDatabase();
			});
			#endregion
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bocasay.Api v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
