using Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Notebook
    {
        public string Id { get; set; }
        public ApplicationUser OwnerId { get; set; }
        public string Name { get; set; }        
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; }
        //public ICollection<Page> Pages { get; set; } = new List<Page>();
    }
}
