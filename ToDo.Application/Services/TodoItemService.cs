using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Infrastructure.Data;

namespace ToDo.Application.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;
        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(ToDoItem newItem, User user)
        {
            var entity = new ToDoItem
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                IsDone = false,
                Description = newItem.Description
               
            };

            _context.ToDoItems.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(User user)
        {
            return await _context.ToDoItems
                .Where(x => x.IsDone == false && x.UserId == user.Id)
                .ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id, User user)
        {
            var item = await _context.ToDoItems
                .Where(x => x.Id == id.ToString() && x.UserId == user.Id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }
    }
}
