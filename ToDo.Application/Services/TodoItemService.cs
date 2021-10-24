using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Interfaces;
using ToDo.Core.Entities;

using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Interfaces;

namespace ToDo.Application.Services
{
    public class TodoItemService : ITodoItemService
    {
        public IToDoRepository _todoRepository;
        public TodoItemService(IToDoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public Task<bool> AddItemAsync(ToDoItem newItem)
        {
            return _todoRepository.AddTodoItems(newItem);
        }

        public Task<bool> DeleteItemAsync(ToDoItem newItem)
        {
            throw new NotImplementedException();
        }
        

        public async Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(string userId)
        {        
            return await _todoRepository.GetToDoItems(userId);
        }

        public Task<bool> MarkDoneAsync(ToDoItem newItem)
        {
            throw new NotImplementedException();
        }
    }
}
