using static VrmDailyPhysicalTest.DTO.VrmDailyPhysicalTestDTO;

namespace VrmDailyPhysicalTest.Interface
{
    public interface IVrmDailyPhysicalTest
    {
        public Task<List<VrmDailyPhysicalTestElementconfigDTO>> GetVrmDailyPhysicalTestElementconfigDDL(long BusinessUnitId);
    }
}
