using HostelProject.Modules.Hostels.Models;
using HostelProject.Modules.Hostels.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelProject.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HostelsController : ControllerBase
    {
        public readonly IHostelServices _HostelServices;
        public HostelsController(IHostelServices hostelServices)
        {
            _HostelServices = hostelServices;

        }
        [HttpGet]
        [Route("Hostels")]
        public IActionResult GetHostels(Guid staffid)
        {
            try
            {
                return Ok(_HostelServices.GetHostels(staffid));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("Hostel/Id")]
        public IActionResult GetHostelById(Guid Id)
        {
            try
            {
                return Ok(_HostelServices.GetHostelById(Id));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("Hostel")]
        public IActionResult PostHostelsDetails([FromBody] HostelsModel mo)
        {
            try
            {
                return Ok(_HostelServices.PostHostelsDetails(mo));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("Hostel/Id")]
        public IActionResult UpdateHostelDetails(HostelsModel model)
        {
            try
            {
                return Ok(_HostelServices.UpdateHostelDetails(model));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("hostelDisable")]
        public IActionResult DisableHostelDetails(Guid id)
        {
            try
            {
                return Ok(_HostelServices.DisableHostelDetails(id));
            }
            catch(Exception e)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("RoomDisable")]
        public IActionResult RoomDisable(Guid id)
        {
            try
            {
                return Ok(_HostelServices.RoomDisable(id));
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
