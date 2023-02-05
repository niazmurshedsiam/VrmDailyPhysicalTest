using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VrmDailyPhysicalTest.Interface;
using static VrmDailyPhysicalTest.DTO.VrmDailyPhysicalTestDTO;

namespace VrmDailyPhysicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VrmDailyPhysicalTestController : ControllerBase
    {
        private readonly IVrmDailyPhysicalTest _iVrmDailyPhysicalTest;
        public VrmDailyPhysicalTestController(IVrmDailyPhysicalTest iVrmDailyPhysicalTest)
        {
            _iVrmDailyPhysicalTest = iVrmDailyPhysicalTest;
        }

        [HttpGet]
        [Route("GetVrmDailyPhysicalTestElementconfigDDL")]
        public async Task<IActionResult> GetVrmDailyPhysicalTestElementconfigDDL(long BusinessUnitId)
        {
            try
            {
                var msg = await _iVrmDailyPhysicalTest.GetVrmDailyPhysicalTestElementconfigDDL(BusinessUnitId);
                return Ok(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("CreateAndEditCargoUnloadingStatement")]
        public async Task<IActionResult> CreateAndEditVrmDailyPhysicalTest(VrmDailyPhysicalTestCommonDTO obj)
        {
            var msg = await _iVrmDailyPhysicalTest.CreateAndEditVrmDailyPhysicalTest(obj);
            return Ok(msg);
        }

        [HttpPost]
        [Route("CreateVrmDailyPhysicalTest")]
        public async Task<IActionResult> CreateVrmDailyPhysicalTest(VrmDailyPhysicalTestCommonDTO obj)
        {
            var msg = await _iVrmDailyPhysicalTest.CreateVrmDailyPhysicalTest(obj);
            return Ok(msg);
        }
    }
}
