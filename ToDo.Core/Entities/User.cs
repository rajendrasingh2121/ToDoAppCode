using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Common;

namespace ToDo.Core.Entities
{
    public class User : AuditableEntity
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<ToDoItem> ToDoItems { get; set; }
    }
}
