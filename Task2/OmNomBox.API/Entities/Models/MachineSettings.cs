using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class MachineSettings
    {
        public Guid MachineSettingsId { get; set; }

        [ForeignKey(nameof(MachineType))]
        public Guid MachineTypeId { get; set; }

        public MachineType? MachineType { get; set; }

        [ForeignKey(nameof(Meal))]
        public Guid MealId { get; set; }

        public Meal? Meal { get; set; }
    }
}
