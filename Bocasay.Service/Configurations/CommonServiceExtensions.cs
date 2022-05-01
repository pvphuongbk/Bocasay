using Microsoft.Extensions.DependencyInjection;
namespace Bocasay.Service.Configurations
{
    public static class CommonServiceExtensions
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommonServiceExtensions).Assembly);
        }
    }
}
