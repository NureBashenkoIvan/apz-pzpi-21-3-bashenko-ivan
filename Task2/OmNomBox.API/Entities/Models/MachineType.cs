using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class MachineType
    {
        public Guid MachineTypeId { get; set; }

        [Required(ErrorMessage = "Machine type name is a required field.")]
        public string? Name { get; set; }

        public ICollection<Machine>? Machines { get; set; }

        public ICollection<MachineSettings>? MachineSettings { get; set; }
    }
}
