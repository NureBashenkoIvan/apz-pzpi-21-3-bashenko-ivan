using Entities.Models;
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
    [Route("api/manufacturers")]
    [ApiController]
    [Authorize]
    public class ManufacturerController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ManufacturerController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetManufacturers([FromQuery] ManufacturerParameters manufacturerParameters)
        {
            var manufacturers =
                await _service.ManufacturerService.GetAllManufacturersAsync(manufacturerParameters, trackChanges: false);
            return Ok(manufacturers);
        }

        [HttpGet("{id:guid}", Name = "ManufacturerById")]
        public async Task<IActionResult> GetManufacturer(Guid id)
        {
            var manufacturer = await _service.ManufacturerService.GetManufacturerAsync(id, trackChanges: false);
            return Ok(manufacturer);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateManufacturer([FromBody] CreateUpdateManufacturerDto manufacturer)
        {
            var createdManufacturer = await _service.ManufacturerService.CreateManufacturerAsync(manufacturer);

            return CreatedAtRoute("ManufacturerById", new { id = createdManufacturer.ManufacturerId },
                createdManufacturer);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteManufacturer(Guid id)
        {
            await _service.ManufacturerService.DeleteManufacturerAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateManufacturer(Guid id, [FromBody] CreateUpdateManufacturerDto manufacturer)
        {
            await _service.ManufacturerService.UpdateManufacturerAsync(id, manufacturer, trackChanges: true);

            return NoContent();
        }
    }
}
