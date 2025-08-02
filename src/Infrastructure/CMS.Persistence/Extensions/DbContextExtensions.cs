using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CMS.Persistence.Data.Interceptors;
using CMS.Persistence.Interceptors;

namespace CMS.Persistence.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContextWithInterceptors(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<SoftDeleteInterceptor>();
            services.AddScoped<UpdateAuditableInterceptor>();

            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    // Resolve interceptors from the container
                    .AddInterceptors(
                        provider.GetRequiredService<SoftDeleteInterceptor>(),
                        provider.GetRequiredService<UpdateAuditableInterceptor>()
                    )
                    .LogTo(Console.WriteLine, LogLevel.Information);

            });

            return services;
        }
    }

}

