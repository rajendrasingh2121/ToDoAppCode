using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDo.Core.Entities;

namespace ToDo.Application.Interfaces
{
    public interface ITodoItemService
    {
         Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(string userId);
         Task<bool> AddItemAsync(ToDoItem newItem);
         Task<bool> MarkDoneAsync(ToDoItem newItem);
        Task<bool> DeleteItemAsync(ToDoItem newItem);
    }
}
