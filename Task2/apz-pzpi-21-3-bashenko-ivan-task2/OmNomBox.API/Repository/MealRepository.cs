using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MealRepository : RepositoryBase<Meal>, IMealRepository
    {
        public MealRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Meal>> GetAllMealsAsync(MealParameters mealParameters, bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .Skip((mealParameters.PageNumber - 1) * mealParameters.PageSize)
                .Take(mealParameters.PageSize)
                .ToListAsync();

        public async Task<Meal> GetMealAsync(Guid mealId, bool trackChanges) =>
            await FindByCondition(c => c.MealId.Equals(mealId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateMeal(Meal meal) => Create(meal);

        public void DeleteMeal(Meal meal) => Delete(meal);
    }
}
