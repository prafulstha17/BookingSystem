using Application.Interface.Client;
using Application.Interface.Common;
using Application.Repositiory;
using Infrastructure.Data;
using Infrastructure.Repositiory.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extentions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AuthDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
            //Static Data
            services.AddScoped<IStaticDataRepository, StaticDataRepository>();
            //Client 
            services.AddScoped<IClientRepo, ClientRepo>();
            //services.AddScoped<IAuthService, AuthService>();
            //middlerware
            return services;
        }
    }

}
