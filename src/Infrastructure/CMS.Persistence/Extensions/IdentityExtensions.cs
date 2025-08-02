using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using CMS.Domain.Entities;

namespace CMS.Persistence.Extensions
{
    public static class IdentityExtensions
    {
         public static void AddAppIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}



