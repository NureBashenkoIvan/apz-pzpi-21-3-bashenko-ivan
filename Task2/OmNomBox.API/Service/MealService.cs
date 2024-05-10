using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class MealService : IMealService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MealService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MealDto>> GetAllMealsAsync(MealParameters mealParameters, bool trackChanges)
        {
            var meals = await _repository.Meal.GetAllMealsAsync(mealParameters, trackChanges);

            var mealsDto = _mapper.Map<IEnumerable<MealDto>>(meals);

            return mealsDto;
        }

        public async Task<MealDto> GetMealAsync(Guid id, bool trackChanges)
        {
            var meal = await GetMealAndCheckIfItExists(id, trackChanges);

            var mealDto = _mapper.Map<MealDto>(meal);

            return mealDto;
        }

        public async Task<MealDto> CreateMealAsync(CreateUpdateMealDto meal)
        {
            var mealEntity = _mapper.Map<Meal>(meal);

            _repository.Meal.CreateMeal(mealEntity);
            await _repository.SaveAsync();

            var mealToReturn = _mapper.Map<MealDto>(mealEntity);
            return mealToReturn;
        }

        public async Task DeleteMealAsync(Guid id, bool trackChanges)
        {
            var meal = await GetMealAndCheckIfItExists(id, trackChanges);

            _repository.Meal.DeleteMeal(meal);
            await _repository.SaveAsync();
        }

        public async Task UpdateMealAsync(Guid mealId, CreateUpdateMealDto mealForUpdate, bool trackChanges)
        {
            var meal = await GetMealAndCheckIfItExists(mealId, trackChanges);

            _mapper.Map(mealForUpdate, meal);
            await _repository.SaveAsync();
        }

        private async Task<Meal> GetMealAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var meal = await _repository.Meal.GetMealAsync(id, trackChanges);
            if (meal is null)
                throw new MealNotFoundException(id);

            return meal;
        }
    }
}
