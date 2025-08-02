using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using CMS.Application.Features.Auth.Models;

namespace CMS.Application
{
    /// <summary>
    /// Extension methods for configuring application services.
    /// </summary>
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //Configure Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            // Configure Fluent Validation
            ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies(), ServiceLifetime.Scoped);
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableBuiltInModelValidation = true;
                config.EnableBodyBindingSourceAutomaticValidation = true;
                config.EnableFormBindingSourceAutomaticValidation = true;
                config.EnableQueryBindingSourceAutomaticValidation = true;
                config.EnablePathBindingSourceAutomaticValidation = true;
            });

            services.Configure<RefreshTokenSettings>(configuration.GetSection("RefreshToken"));

            return services;
        }
    }
}



