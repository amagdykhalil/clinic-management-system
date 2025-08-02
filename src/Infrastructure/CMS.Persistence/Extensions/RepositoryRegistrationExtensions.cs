using Microsoft.Extensions.DependencyInjection;
using CMS.Application.Contracts.Persistence.Base;

namespace CMS.Persistence.Extensions
{
    public static class RepositoryRegistrationExtensions
    {
        public static IServiceCollection ScanAndRegisterRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
                 .FromAssembliesOf(typeof(PersistenceDependencyInjection))
                 .AddClasses(classes => classes.AssignableTo<IRepository>())
                 .As((type) =>
                     type.GetInterfaces()
                         .Where(i => typeof(IRepository).IsAssignableFrom(i) && i != typeof(IRepository))
                 )
                 .AsImplementedInterfaces()
                 .WithScopedLifetime()
             );

            return services;
        }
    }

}

