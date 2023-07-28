using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vedaproject.Model;
using vedaproject.Services;
using vedaproject.vedaproject.Context;
using vedaproject.vedaproject.Entity;

namespace vedaproject.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        public readonly IStaffServices _staffServices;

        public StaffController(IStaffServices staffServices)
        {
            _staffServices = staffServices;
        }

        [HttpGet]
        [Route("Staff/staffid")]
        public IActionResult Staffid(Guid staffId)
        {
            try
            {
                return Ok(_staffServices.Staffid(staffId));

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("StaffListdata")]
        public IActionResult Staffdata()
        {
            try
            {
                return Ok(_staffServices.Staffdata());

            }
            catch (Exception)
            {

                throw;
            }
           
        }
        [HttpPost]
        [Route("StaffInsert")]
          public IActionResult StaffInsert(StaffModel model)
        {
            try
            {
                return Ok(_staffServices.StaffInsert(model));

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("StaffUpdate")]
        public IActionResult StaffUpdate(StaffModel mo)
        {
            try
            {
                return Ok(_staffServices.StaffUpdate(mo));

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("Staffdisable")]
        public IActionResult Staffdisable(Guid id)
        {
            try
            {
                return Ok(_staffServices.Staffdisable(id));

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("HostelLookup")]
        public IActionResult HostelLookup(Guid Id)
        {
            try
            {
                return Ok(_staffServices.HostelLookup(Id));

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("IdProofLookup")]
        public IActionResult IdProofLookup(Guid Id)
        {
            try
            {
                return Ok(_staffServices.IdProofLookup(Id));

            }
            catch (Exception)
            {

                throw;
            }
        }



    }
    }

