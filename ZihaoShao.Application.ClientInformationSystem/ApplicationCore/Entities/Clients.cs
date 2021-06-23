using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    //clients entities
    public class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phones { get; set; }
        public string Address { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? AddedBy { get; set; }
        public Employees Employees { get; set; }
        //public ICollection<Interactions> Interactions { get; set; }

    }
}
