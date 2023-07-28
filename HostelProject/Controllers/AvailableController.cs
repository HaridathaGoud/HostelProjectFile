using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veda_Project_Sample.Context;
using Veda_Project_Sample.Modal;
using Veda_Project_Sample.Services;

namespace Veda_Project_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableController : ControllerBase
    {
        private readonly IAvailableService _availableService;
        public AvailableController(IAvailableService availableService)
        {
            _availableService = availableService;
        }

        [HttpGet]
        [Route("GetAvailibilityAllData")]
        public IActionResult GetAvailibilityAllData(Guid id)
        {
            return Ok(_availableService.GetAvailibilityAllData(id));
        }
        [HttpGet]
        [Route("GetLoopupData")]
        public IActionResult GetLoopupData(Guid id)
        {
            return Ok(_availableService.GetLoopupData(id));
        }
        [HttpGet]
        [Route("AllAvailibilityData")]
        public IActionResult AllAvailibilityData()
        {
            return Ok(_availableService.AllAvailibilityData());
        }
    }
}
