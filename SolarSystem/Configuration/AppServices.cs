using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolarSystem.Data;
using SolarSystem.Data.Models;
using SolarSystem.Service.Interfaces;
using SolarSystem.Service.BusinessService;

namespace SolarSystem.Configuration
{
    public static class AppServices
    {
        public static void AddDefaultServices(this IServiceCollection serviceCollection, IConfiguration Configuration)
        {
            serviceCollection.AddDbContext<SolarSystemContext>();

            serviceCollection.AddAuthentication();

            serviceCollection.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<SolarSystemContext>();

            serviceCollection.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Home/Login");
                opt.Cookie.Name = "SolarSystem";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });

            serviceCollection.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public static void AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPlanetService, PlanetService>();
            serviceCollection.AddScoped<ISatelliteService, SatelliteService>();
            serviceCollection.AddScoped<IPlanetSatelliteService, PlanetSatelliteService>();
            serviceCollection.AddScoped<IRecentNewsService, RecentNewsService>();
        }
    }
}
