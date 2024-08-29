using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Page
    {
        public string Id { get; set; }
        public string NotebookId { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; }
    }
}
