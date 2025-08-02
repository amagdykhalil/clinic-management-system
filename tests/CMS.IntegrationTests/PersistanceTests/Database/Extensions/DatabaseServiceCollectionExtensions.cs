using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CMS.Application.Abstractions.Services;
using CMS.Application.Features.Auth.Models;
using CMS.Infrastructure.Common.Services;
using CMS.Persistence;
using CMS.Persistence.Extensions;
using CMS.Persistence.Identity;
using CMS.Persistence.Repositories;
using CMS.Persistence.UoW;

namespace CMS.IntegrationTests.Infrastructure.Extensions
{
    public static class DatabaseServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDatabaseServices(this IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("No connection string was found.");
            }

            return services
                .ConfigureLogging()
                .ConfigureIdentity()
                .ConfigureDbContext(connectionString)
                .ConfigureRepositories()
                .Configure<RefreshTokenSettings>(configuration.GetSection("RefreshToken"));
        }

        private static IServiceCollection ConfigureLogging(this IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddDebug();
                builder.SetMinimumLevel(LogLevel.Warning);
            });

            return services;
        }

        private static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services.AddAppIdentity();
            return services;
        }

        private static IServiceCollection ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.ScanAndRegisterRepositories();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}

