using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class MachineStatus
    {
        public Guid MachineStatusId { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string? Description { get; set; }
    }
}
