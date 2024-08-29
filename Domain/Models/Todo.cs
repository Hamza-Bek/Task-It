using Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Todo
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }        
        public bool IsDone { get; set; }
        public string? Priority { get; set; }
        public string? TodoCollectionId { get; set; }        
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
                     
       
    }
}
