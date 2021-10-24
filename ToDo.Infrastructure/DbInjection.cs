using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Identity;


namespace ToDo.Infrastructure
{
    public static class DbInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)//, IWebHostEnvironment environment)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb"));


            services.AddDefaultIdentity<ApplicationUser>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI().AddDefaultTokenProviders();
            return services;
        }

      
    }
        
}
