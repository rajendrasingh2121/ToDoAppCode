using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Common;

namespace ToDo.Core.Entities
{
   public class ToDoItem : AuditableEntity
    {
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsDone { get; set; }
        public string UserId { get; set; }

    }
}
