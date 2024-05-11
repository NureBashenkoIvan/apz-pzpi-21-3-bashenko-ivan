using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Machine
    {
        public Guid MachineId { get; set; }

        [Required(ErrorMessage = "Machine is a required field.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Serial number is a required field.")]
        public string? SerialNumber { get; set; }

        [ForeignKey(nameof(MachineType))]
        public Guid? MachineTypeId { get; set; }

        [ForeignKey(nameof(MachineStatus))]
        public Guid? MachineStatusId { get; set; }

        [ForeignKey(nameof(Manufacturer))]
        public Guid? ManufacturerId { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid? CompanyId { get; set; }

        public string? Location { get; set; }

        public DateTime? InstallationDate { get; set; }

        public DateTime? LastMaintenanceDate { get; set; }

        public MachineType? MachineType { get; set; }

        public MachineStatus? MachineStatus { get; set; }

        public Manufacturer? Manufacturer { get; set; }

        public Company? Company { get; set; }
    }
}
