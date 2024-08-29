using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TodoCollection
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }       
        public string? Color { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}
