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

           /// services.AddIdentityCore<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            return services;
        }

        public static void AddTestData(ApplicationDbContext context)
        {
            var testUser1 = new User
            {
                Id = "abc123",
                FirstName = "Luke",
                LastName = "Skywalker"
            };

            context.Users.Add(testUser1);

            var testPost1 = new ToDoItem
            {
                Id = "def234",
                UserId = testUser1.Id,
                Description ="test1",
                IsDone=false
            };

            context.ToDoItems.Add(testPost1);

            context.SaveChanges();
        }
    }
        
}
