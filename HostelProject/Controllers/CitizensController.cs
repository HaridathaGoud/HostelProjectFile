using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Modules.Context;
using ProjectApi.Modules.Models;
using ProjectApi.Modules.Services;

namespace HostelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizensController : ControllerBase
    {
        private readonly CitizenContext _citizenContext;
        private readonly ICitizenService _services;

        public CitizensController(CitizenContext citizenContext, ICitizenService services)
        {
            _citizenContext = citizenContext;
            _services = services;
        }
        [HttpGet]
        [Route("Citizen")]
        public IActionResult Citizen(Guid id)
        {
            try
            {
                return Ok(_services.GetCitizens(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("citizen")]
        public IActionResult Citizen(CitizenModel model)
        {
            try
            {
                return Ok(_services.PostCitizens(model));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        [Route("citizen")]
        public IActionResult citizens(CitizenModel model)
        {
            try
            {
                return Ok(_services.UpDateCitizen(model));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("Citizens")]
        public IActionResult GetHostles(Guid id)
        {
            try
            {
                return Ok(_services.GetHostles( id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("Hostels")]
        public IActionResult Hostels(Guid id)
        {
            try
            {
                return Ok(_services.HostelLookup(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("v1/Hostels")]
        public IActionResult Rooms(Guid Id)
        {
            try
            {
                return Ok(_services.RoomsLookUp(Id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("v1/Idproof")]
        public IActionResult IdProof(Guid Id)
        {
            try
            {
                return Ok(_services.IdProof(Id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        [Route("v1/CitizenDisable")]
        public IActionResult CitizenDisable(Guid Id)
        {
            try
            {
                return Ok(_services.CitizenDisable(Id));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
