using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.Interfaces
{

    public interface IToDoRepository
    {

        Task<IEnumerable<ToDoItem>>GetToDoItems(string userId);
        Task<bool> AddTodoItems(ToDoItem model);
        Task<bool> UpdateTodoItems(ToDoItem model);
        Task<bool> DeleteTodoItemsAsync(int? Id);
        
    }
    
}
