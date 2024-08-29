using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TodoCollection : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Color { get; set; }
        public ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}
