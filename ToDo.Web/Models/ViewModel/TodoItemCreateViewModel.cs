using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Web.Models.ViewModel
{
    public class TodoItemCreateViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Description { get; set; }

     

        
    }
}
