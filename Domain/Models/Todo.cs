using Domain.Enums;
using Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Todo : ModelBase
    {
        public string TodoCollectionId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Content { get; set; }
        public bool IsDone { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
    }
}
