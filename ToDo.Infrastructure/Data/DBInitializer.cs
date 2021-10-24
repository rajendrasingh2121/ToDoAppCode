using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Infrastructure.Identity;

namespace ToDo.Infrastructure.Data
{
    public static class DBInitializer
    {
    
        public static void Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            using (var context = new ApplicationDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var testUser1 = new ApplicationUser
                {
                    Id = "test",
                    UserName = "test",
                    Email = "test@gmail.com"
                };

                IdentityResult result = userManager.CreateAsync(testUser1, "pwd123").Result;
            
                if (result.Succeeded)
                {
                    var testPost1 = new ToDoItem
                    {
                        Id = 1,
                        UserId = testUser1.Id,
                        Description = "test1",
                        IsDone = false
                    };

                    context.ToDoItems.Add(testPost1);

                    context.SaveChanges();
                }
                
            }
        }  

     
    }

}
