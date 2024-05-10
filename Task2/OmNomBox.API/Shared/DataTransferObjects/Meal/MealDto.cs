using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MealDto(Guid MealId, string Name, string Description, double PreparationTime, double Price);
}
