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
    [Route("api/companies/{companyId}/machines")]
    [ApiController]
    [Authorize]
    public class MachineController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MachineController(IServiceManager service) => _service = service;

        [HttpGet("admin")]
        public async Task<IActionResult> GetAllMachines([FromQuery] MachineParameters machineParameters)
        {
            var machines = await _service.MachineService.GetAllMachinesAsync(machineParameters, trackChanges: false);

            return Ok(machines);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMachinesForCompany(Guid companyId, [FromQuery] MachineParameters machineParameters)
        {
            var machines = await _service.MachineService.GetAllMachinesForCompanyAsync(companyId, machineParameters,
                trackChanges: false);

            return Ok(machines);
        }

        [HttpGet("{id:guid}", Name = "GetMachineForCompany")]
        public async Task<IActionResult> GetMachineForCompany(Guid companyId, Guid id)
        {
            var machine = await _service.MachineService.GetMachineAsync(companyId, id, trackChanges: false);
            return Ok(machine);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMachineForCompany(Guid companyId, [FromBody] CreateUpdateMachineDto machine)
        {
            var machineToReturn = await _service.MachineService.CreateMachineAsync(companyId, machine, trackChanges: false);

            return CreatedAtRoute("GetMachineForCompany", new
            {
                companyId,
                id = machineToReturn.MachineId,
            }, machineToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMachineForCompany(Guid companyId, Guid id)
        {
            await _service.MachineService.DeleteMachineAsync(companyId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMachineForCompany(Guid companyId, Guid id,
            [FromBody] CreateUpdateMachineDto machine)
        {
            await _service.MachineService.UpdateMachineAsync(companyId, id, machine, trackChanges: true);

            return NoContent();
        }
    }
}
