using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record OrderDto(Guid OrderId, DateTime OrderDate, Guid MachineId, Guid CompanyId, Guid MealId, decimal TotalAmount, decimal Price, string UserId)
    {
        public OrderDto() : this(Guid.Empty, DateTime.Now, Guid.Empty, Guid.Empty, Guid.Empty, 0, 0, "") { }
    }
}
