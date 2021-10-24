using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Web.ViewModel
{

   public class ToDoItemViewModel
    {   
        public IEnumerable<ToDoItem> ToDoItems { get; set; }
    }
}
