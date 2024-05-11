using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMealService
    {
        Task<IEnumerable<MealDto>> GetAllMealsAsync(MealParameters mealParameters, bool trackChanges);
        Task<MealDto> GetMealAsync(Guid id, bool trackChanges);
        Task<MealDto> CreateMealAsync(CreateUpdateMealDto meal);
        Task DeleteMealAsync(Guid id, bool trackChanges);
        Task UpdateMealAsync(Guid mealId, CreateUpdateMealDto mealForUpdate, bool trackChanges);
    }
}
