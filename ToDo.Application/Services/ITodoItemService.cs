using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Application.Services
{
    public interface ITodoItemService
    {
         Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(User user);
         Task<bool> AddItemAsync(ToDoItem newItem, User user);
         Task<bool> MarkDoneAsync(Guid id, User user);
    }
}
