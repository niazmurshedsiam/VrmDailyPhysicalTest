using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VrmDailyPhysicalTest.Interface;

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
    }
}
