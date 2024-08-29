using Domain.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Note
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string Title{ get; set; }
        public string? Content{ get; set; }        
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; }
        
    }
}
