using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class PageRequest
    {
        public string? SearchQuery { get; set; } = string.Empty;
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
