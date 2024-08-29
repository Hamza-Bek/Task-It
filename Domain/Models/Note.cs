using Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Note : ModelBase
    {
        public string Title { get; set; } = string.Empty;
        public string? Content { get; set; }
        public bool IsDeleted { get; set; }
    }
}
