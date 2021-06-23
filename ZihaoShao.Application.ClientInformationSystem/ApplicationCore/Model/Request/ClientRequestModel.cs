using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class ClientRequestModel
    {
        [Required(ErrorMessage = "Make sure you enter client's name!")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phones { get; set; }
        [StringLength(2084)]
        public string Address { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
