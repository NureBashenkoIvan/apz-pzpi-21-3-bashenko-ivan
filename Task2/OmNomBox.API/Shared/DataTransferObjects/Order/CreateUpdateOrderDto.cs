using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CreateUpdateOrderDto(Guid MachineId, Guid CompanyId, Guid MealId, decimal TotalAmount, decimal Price);
}
