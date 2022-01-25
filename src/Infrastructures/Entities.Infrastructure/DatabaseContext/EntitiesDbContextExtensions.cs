using Entities.Domain.Users;
using Entities.Infrastructure.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entities.Infrastructure.DatabaseContext
{
    public static class EntitiesDbContextExtensions
    {
        public static IServiceCollection AddDbUserContext(this IServiceCollection services, string connectionString, string identityConnectionString = "")
        {
            if (string.IsNullOrEmpty(identityConnectionString))
            {
                identityConnectionString = connectionString;
            }

            var migrationAssemby = typeof(EntitiesDbContextExtensions).Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(identityConnectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<ApplicationUser>()
                .AddConfigurationStore(options => options.ConfigureDbContext = b => b.UseSqlServer(identityConnectionString, sql => sql.MigrationsAssembly(migrationAssemby)))
                .AddOperationalStore(options => options.ConfigureDbContext = b => b.UseSqlServer(identityConnectionString, sql => sql.MigrationsAssembly(migrationAssemby)));

            services.AddDbContext<EntitiesDbContext>(builder => builder.UseSqlServer(connectionString));
            services.AddScoped<IUserDbContext, UserDbContext>();

            return services;
        }
    }
}
