using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMealRepository
    {
        Task<IEnumerable<Meal>> GetAllMealsAsync(MealParameters mealParameters, bool trackChanges);
        Task<Meal> GetMealAsync(Guid mealId, bool trackChanges);
        void CreateMeal(Meal meal);
        void DeleteMeal(Meal meal);
    }
}
