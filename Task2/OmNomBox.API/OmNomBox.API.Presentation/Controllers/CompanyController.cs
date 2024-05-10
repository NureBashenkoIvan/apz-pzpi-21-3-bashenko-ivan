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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OmNomBox.API.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CompanyController(IServiceManager service) => _service = service;

        [HttpGet("admin")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCompaniesForAdmin([FromQuery] CompanyParameters companyParameters)
        {
            var companies =
                await _service.CompanyService.GetAllCompaniesAsync(companyParameters, trackChanges: false);
            return Ok(companies);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies([FromQuery] CompanyParameters companyParameters)
        {
            var userId = User.Claims.FirstOrDefault()?.Value;
            var companies =
                await _service.CompanyService.GetAllCompaniesForUserAsync(userId, companyParameters, trackChanges: false);
            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _service.CompanyService.GetCompanyAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CreateUpdateCompanyDto company)
        {
            var userId = User.Claims.FirstOrDefault()?.Value;
            var createdCompany = await _service.CompanyService.CreateCompanyAsync(userId, company);

            return CreatedAtRoute("CompanyById", new { id = createdCompany.CompanyId },
                createdCompany);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _service.CompanyService.DeleteCompanyAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CreateUpdateCompanyDto company)
        {
            await _service.CompanyService.UpdateCompanyAsync(id, company, trackChanges: true);

            return NoContent();
        }
    }
}
