using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;

using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Interfaces;

namespace ToDo.Infrastructure.Repositories
{
  
    public class ToDoRepository : IToDoRepository
    {
        private readonly ApplicationDbContext _context;
        public ToDoRepository(ApplicationDbContext context)
        {
            _context = context;
          
        }

        public async Task<bool> AddTodoItems(ToDoItem model)
        {
            var entity = new ToDoItem
            {               
                UserId = model.UserId,
                IsDone = false,
                Description = model.Description

            };

            _context.ToDoItems.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One
        
        }

        public async Task<bool> DeleteTodoItemsAsync(int? Id)
        {
            var item = await _context.ToDoItems
                .Where(x => x.Id == Id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            _context.ToDoItems.Remove(item);

             var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }     

        public async Task<IEnumerable<ToDoItem>> GetToDoItems(string userId)
        {
            return await _context.ToDoItems
                .Where(x => x.IsDone == false && x.UserId == userId).ToArrayAsync(); 
               
        }


        public async Task<bool> UpdateTodoItems(ToDoItem model)
        {
            throw new NotImplementedException();
        }
    }
}
