using CleanApp.Application;
using CleanApp.Application.Common.Interfaces;
using CleanApp.Infrastructure.Files;
//using CleanApp.Infrastructure.Identity;
using CleanApp.Infrastructure.Persistence;
using CleanApp.Infrastructure.Services;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace CleanApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        configuration.GetConnectionString("DefaultConnection"), 
            //        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            // requires using Microsoft.Extensions.Options
            services.Configure<DatabaseSettings>(
                configuration.GetSection(nameof(DatabaseSettings)));

            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);


            //services.AddSingleton<IADODBContext>(provider => provider.GetService<ADODBContext>());
            //services.AddSingleton<ADODBContext>();

            services.AddSingleton(typeof(IADODBContext<>), typeof(ADODBContext<>));
            //services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepository<>));

            if (environment.IsEnvironment("Test"))
            {
                //services.AddIdentityServer()
                //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                //    {
                //        options.Clients.Add(new Client
                //        {
                //            ClientId = "CleanApp.IntegrationTests",
                //            AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                //            ClientSecrets = { new Secret("secret".Sha256()) },
                //            AllowedScopes = { "CleanApp.WebUIAPI", "openid", "profile" }
                //        });
                //    })
                //    .AddTestUsers(new List<TestUser>
                //    {
                //        new TestUser
                //        {
                //            SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
                //            Username = "jason@clean-architecture",
                //            Password = "CleanApp!",
                //            Claims = new List<Claim>
                //            {
                //                new Claim(JwtClaimTypes.Email, "jason@clean-architecture")
                //            }
                //        }
                //    });
            }
            else
            {
                //services.AddIdentityServer()
                //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

                services.AddTransient<IDateTime, DateTimeService>();
                //services.AddTransient<IIdentityService, IdentityService>();
                //services.AddTransient<ILicensingService>(ls => new LicensingService(configuration["Data:ConnectionString"]));
                services.AddTransient<IConversionService, ConversionService>();
                services.AddTransient<ISecurityService, SecurityService>();
            }

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
