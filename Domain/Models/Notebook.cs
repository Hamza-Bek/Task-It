using Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Notebook : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public ICollection<Page> Pages { get; set; } = new List<Page>();
    }
}
