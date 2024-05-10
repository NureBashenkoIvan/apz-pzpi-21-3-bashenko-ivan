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
    [Route("api/machineStatuses")]
    [ApiController]
    [Authorize]
    public class MachineStatusController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MachineStatusController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetMachineStatuses([FromQuery] MachineStatusParameters machineStatusParameters)
        {
            var machineStatuses =
                await _service.MachineStatusService.GetAllMachineStatusesAsync(machineStatusParameters, trackChanges: false);
            return Ok(machineStatuses);
        }

        [HttpGet("{id:guid}", Name = "MachineStatusById")]
        public async Task<IActionResult> GetMachineStatus(Guid id)
        {
            var machineStatus = await _service.MachineStatusService.GetMachineStatusAsync(id, trackChanges: false);
            return Ok(machineStatus);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMachineStatus([FromBody] CreateUpdateMachineStatusDto machineStatus)
        {
            var createdMachineStatus = await _service.MachineStatusService.CreateMachineStatusAsync(machineStatus);

            return CreatedAtRoute("MachineStatusById", new { id = createdMachineStatus.MachineStatusId },
                createdMachineStatus);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMachineStatus(Guid id)
        {
            await _service.MachineStatusService.DeleteMachineStatusAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMachineStatus(Guid id, [FromBody] CreateUpdateMachineStatusDto machineStatus)
        {
            await _service.MachineStatusService.UpdateMachineStatusAsync(id, machineStatus, trackChanges: true);

            return NoContent();
        }
    }
}
