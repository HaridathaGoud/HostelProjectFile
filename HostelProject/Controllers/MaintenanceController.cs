using HostelProject.Modules.Maintenance.MaintenanceModel;
using HostelProject.Modules.Maintenance.MaintenanceServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelProject.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly MaintanIservices _maintanIservices;

        public MaintenanceController(MaintanIservices maintanIservices)
        {
            _maintanIservices = maintanIservices;
        }

        // Get Hostels 
        [HttpGet]
        [Route("HostelLockUp")]
        public IActionResult HostelLockUp(Guid Id)
        {
            try
            {
                return Ok(_maintanIservices.HostelLockUp(Id));
            }
            catch (Exception)
            {
                throw new Exception("Something Wrong . ");
            }
        }


        // Getting Data
        [HttpGet]
        [Route("GetMaintanaceData")]
        public IActionResult GetMaintanaceData()
        {
            try
            {
                return Ok(_maintanIservices.GetMaintanaceData());
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Joining Maintenance table and Document Table and Getting Data
        [HttpGet]
                [Route("MaintenaceDocumentData")]
                public IActionResult MaintenaceDocumentData()
                {
                    try
                    {
                        return Ok(_maintanIservices.MaintenaceDocumentData());
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }



                //Add Record
                [HttpPost]
                [Route("MaintenanceAdd")]
                public IActionResult MaintenanceAdd(MaintainAddmodel addmodel)
                {
                    try
                    {
                        return Ok(_maintanIservices.MaintenanceAdd(addmodel));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                // updating 
                [HttpPut]
                [Route("UpdateMaintanceRecord")]
                public IActionResult UpdateMaintanceRecord(MaintainAddmodel addmodel)
                {
                    try
                    {
                        return Ok(_maintanIservices.UpdateMaintanceRecord(addmodel));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }







                // ------------------------------------------------------- //





                //// desable
                //[HttpPut]
                //[Route("MaintanDesable")]
                //public IActionResult MaintanDisable(Guid Id)
                //{
                //    try
                //    {
                //        return Ok(_maintanIservices.MaintanDisable(Id));
                //    }
                //    catch (Exception e)
                //    {
                //        throw;
                //    }
                //}
            }
}
