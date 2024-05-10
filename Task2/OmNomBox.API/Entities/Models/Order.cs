using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(Machine))]
        public Guid MachineId { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }

        [ForeignKey(nameof(Meal))]
        public Guid MealId { get; set; }

        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Total amount is a required field.")]
        public decimal TotalAmount { get; set; }  
        
        public decimal Price { get; set; }

        public Machine? Machine { get; set; }

        public Company? Company { get; set; }

        public Meal? Meal { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
