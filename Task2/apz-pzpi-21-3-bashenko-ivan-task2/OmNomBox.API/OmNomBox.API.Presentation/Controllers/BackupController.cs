using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmNomBox.API.Presentation.Controllers
{
    [Route("api/backup")]
    [ApiController]
    [Authorize]
    public class BackupController : ControllerBase
    {
        private readonly IServiceManager _service;

        public BackupController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateDbBackup()
        {
            try
            {
                _service.BackupService.CreateBackup();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Backup creation failed: {ex.Message}");
            }
        }
    }
}
