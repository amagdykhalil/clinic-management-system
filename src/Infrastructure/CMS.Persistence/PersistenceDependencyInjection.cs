using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CMS.Application.Abstractions.UserContext;
using CMS.Application.Contracts.Persistence.UoW;
using CMS.Persistence.Extensions;
using CMS.Persistence.Identity;
using CMS.Persistence.UoW;

namespace CMS.Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();

            services.AddAppIdentity();
            services.AddDbContextWithInterceptors(configuration);
            services.ScanAndRegisterRepositories();

            return services;
        }
    }
}



