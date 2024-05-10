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
    [Route("api/machineTypes/{machineTypeId}/machineSettings")]
    [ApiController]
    [Authorize]
    public class MachineSettingsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MachineSettingsController(IServiceManager service) => _service = service;

        [HttpGet("admin")]
        public async Task<IActionResult> GetAllMachineSettings([FromQuery] MachineSettingsParameters machineSettingsParameters)
        {
            var machineSettings = await _service.MachineSettingsService.GetAllMachineSettingsAsync(machineSettingsParameters, trackChanges: false);

            return Ok(machineSettings);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMachineSettingsForMachineType(Guid machineTypeId, [FromQuery] MachineSettingsParameters machineSettingsParameters)
        {
            var machineSettings = await _service.MachineSettingsService.GetAllMachineSettingsForMachineTypeAsync(machineTypeId, machineSettingsParameters,
                trackChanges: false);

            return Ok(machineSettings);
        }

        [HttpGet("{id:guid}", Name = "GetMachineSettingsForMachineType")]
        public async Task<IActionResult> GetMachineSettings(Guid machineSettingsId)
        {
            var machineSettings = await _service.MachineSettingsService.GetMachineSettingsAsync(machineSettingsId, trackChanges: false);
            return Ok(machineSettings);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMachineSettingsForMachineType(Guid machineTypeId, [FromBody] CreateUpdateMachineSettingsDto machineSettings)
        {
            var machineSettingsToReturn = await _service.MachineSettingsService.CreateMachineSettingsAsync(machineTypeId, machineSettings);

            return CreatedAtRoute("GetMachineSettingsForMachineType", new
            {
                machineTypeId,
                id = machineSettingsToReturn.MachineSettingsId,
            }, machineSettingsToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMachineSettings(Guid id)
        {
            await _service.MachineSettingsService.DeleteMachineSettingsAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMachineSettings(Guid machineTypeId, Guid machineSettingsId,
            [FromBody] CreateUpdateMachineSettingsDto machineSettings)
        {
            await _service.MachineSettingsService.UpdateMachineSettingsAsync(machineTypeId, machineSettingsId, machineSettings, trackChanges: true);

            return NoContent();
        }
    }
}
