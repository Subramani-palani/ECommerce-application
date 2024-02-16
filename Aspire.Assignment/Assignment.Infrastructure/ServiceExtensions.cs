using Assignment.Contracts.Data;
using Assignment.Core.Data;
using Assignment.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Data.Repositories;
using Assignment.Infrastructure.Data.Repositories;

namespace Assignment.Infrastructure
{
    public static class ServiceExtensions
    {
        private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            
            // return services.AddSqlite<DatabaseContext>(configuration.GetConnectionString("DefaultConnection"), (options) =>
            // {
            //     options.MigrationsAssembly("Assignment.Migrations");
            // });

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>(); Removed this Existing User Repository.

            //Configuring the Identity Service.
            services.AddIdentity<ApplicationUser,ApplicationRole>(options => {
                // //Password Complexity Configuration
                // options.Password.RequiredLength = 8;
                // options.Password.RequireUppercase = true;
                // options.Password.RequireDigit = true;
                // options.Password.RequireLowercase = true;
            })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders()
            .AddUserStore<UserStore<ApplicationUser,ApplicationRole,DatabaseContext,Guid>>()
            .AddRoleStore<RoleStore<ApplicationRole,DatabaseContext,Guid>>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtService,JwtService>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            
            return services.AddDatabaseContext(configuration).AddUnitOfWork();
        }
    }
}
