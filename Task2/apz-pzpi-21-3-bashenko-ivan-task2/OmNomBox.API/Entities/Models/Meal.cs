using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Meal
    {
        public Guid MealId { get; set; }

        [Required(ErrorMessage = "Meal name is a required field.")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Preparation time is a required field.")]
        public double PreparationTime { get; set; }

        [Required(ErrorMessage = "Price is a required field.")]
        public double Price { get; set; }

        public ICollection<MachineSettings>? MachineSettings { get; set; }
    }
}
