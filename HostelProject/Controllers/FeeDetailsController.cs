using HostelProject.modules.FeeDetails.FeeModel;
using HostelProject.Modules.FeeDetails.FeeService;
using Microsoft.AspNetCore.Mvc;

namespace HostelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeDetailsController : ControllerBase
    {
        private readonly  FeeDIservice _feeService;
        public FeeDetailsController(FeeDIservice feeDIservice )
        {
            _feeService = feeDIservice;
        }
        [HttpGet]
        [Route("GetFeeDetails/Id")]
        public IActionResult GetId(Guid Id)
        {
            return Ok(_feeService.GetId(Id));
        }
        [HttpGet]
        [Route("GetFeeDetails")]
       public ActionResult Gets()
        {
            return Ok(_feeService.Gets());
        }
        [HttpPost]
        [Route("InsertFeeDetailValues")]
        public ActionResult Posts(FeeModels feeModel)
        {
            return Ok(_feeService.Posts(feeModel));
        }

        [HttpGet]
        [Route("GetHostelNameLookup")]
        public ActionResult getHostelName(Guid Id)
        {
            try
            {
                return Ok(_feeService.getHostelName(Id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetRoomNoLookUp")]
        public ActionResult GetRoomNo(Guid Id)
        {
            try
            {
                return Ok(_feeService.GetRoomNo(Id));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
