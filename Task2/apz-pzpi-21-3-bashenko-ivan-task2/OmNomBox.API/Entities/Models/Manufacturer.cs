using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Manufacturer
    {
        public Guid ManufacturerId { get; set; }

        [Required(ErrorMessage = "Manufacturer name is a required field.")]
        public string? Name { get; set; }

        public ICollection<Machine>? Machines { get; set; }
    }
}
