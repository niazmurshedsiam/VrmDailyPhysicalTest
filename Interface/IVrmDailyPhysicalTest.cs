using VrmDailyPhysicalTest.Helper;
using static VrmDailyPhysicalTest.DTO.VrmDailyPhysicalTestDTO;

namespace VrmDailyPhysicalTest.Interface
{
    public interface IVrmDailyPhysicalTest
    {
        public Task<List<VrmDailyPhysicalTestElementconfigDTO>> GetVrmDailyPhysicalTestElementconfigDDL(long BusinessUnitId);
        public Task<MessageHelper> CreateAndEditVrmDailyPhysicalTest(VrmDailyPhysicalTestCommonDTO obj);
        public Task<MessageHelper> CreateVrmDailyPhysicalTest(VrmDailyPhysicalTestCommonDTO obj);
    }
}
