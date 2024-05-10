using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmNomBox.API.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmNomBox.API.Presentation.Controllers
{
    [Route("api/meals")]
    [ApiController]
    [Authorize]
    public class MealController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MealController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetMeals([FromQuery] MealParameters mealParameters)
        {
            var meals =
                await _service.MealService.GetAllMealsAsync(mealParameters, trackChanges: false);
            return Ok(meals);
        }

        [HttpGet("{id:guid}", Name = "MealById")]
        public async Task<IActionResult> GetMeal(Guid id)
        {
            var meal = await _service.MealService.GetMealAsync(id, trackChanges: false);
            return Ok(meal);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMeal([FromBody] CreateUpdateMealDto meal)
        {
            var createdMeal = await _service.MealService.CreateMealAsync(meal);

            return CreatedAtRoute("MealById", new { id = createdMeal.MealId },
                createdMeal);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMeal(Guid id)
        {
            await _service.MealService.DeleteMealAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMeal(Guid id, [FromBody] CreateUpdateMealDto meal)
        {
            await _service.MealService.UpdateMealAsync(id, meal, trackChanges: true);

            return NoContent();
        }
    }
}
