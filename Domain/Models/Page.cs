using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Page : ModelBase
    {
        public string NotebookId { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
