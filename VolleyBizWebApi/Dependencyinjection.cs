using Microsoft.EntityFrameworkCore;
using VolleyBizWebApi.Applications.Interfaces;
using VolleyBizWebApi.Domain.DataContext;
using VolleyBizWebApi.Infrastructure.Providers;

namespace VolleyBizWebApi
{
    public static class  Dependencyinjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration _configuration)
        {

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddDbContext<Context>(options =>
             options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
