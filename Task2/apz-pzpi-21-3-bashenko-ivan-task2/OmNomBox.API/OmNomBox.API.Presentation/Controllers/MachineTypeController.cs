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
    [Route("api/machineTypes")]
    [ApiController]
    [Authorize]
    public class MachineTypeController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MachineTypeController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetMachineTypes([FromQuery] MachineTypeParameters machineTypeParameters)
        {
            var machineTypes =
                await _service.MachineTypeService.GetAllMachineTypesAsync(machineTypeParameters, trackChanges: false);
            return Ok(machineTypes);
        }

        [HttpGet("{id:guid}", Name = "MachineTypeById")]
        public async Task<IActionResult> GetMachineType(Guid id)
        {
            var machineType = await _service.MachineTypeService.GetMachineTypeAsync(id, trackChanges: false);
            return Ok(machineType);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMachineType([FromBody] CreateUpdateMachineTypeDto machineType)
        {
            var createdMachineType = await _service.MachineTypeService.CreateMachineTypeAsync(machineType);

            return CreatedAtRoute("MachineTypeById", new { id = createdMachineType.MachineTypeId },
                createdMachineType);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMachineType(Guid id)
        {
            await _service.MachineTypeService.DeleteMachineTypeAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMachineType(Guid id, [FromBody] CreateUpdateMachineTypeDto machineType)
        {
            await _service.MachineTypeService.UpdateMachineTypeAsync(id, machineType, trackChanges: true);

            return NoContent();
        }
    }
}
