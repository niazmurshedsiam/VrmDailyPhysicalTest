using Microsoft.EntityFrameworkCore;
using VrmDailyPhysicalTest.DbContexts;
using VrmDailyPhysicalTest.DTO;
using VrmDailyPhysicalTest.Interface;
using VrmDailyPhysicalTest.Models;
using static VrmDailyPhysicalTest.DTO.VrmDailyPhysicalTestDTO;

namespace VrmDailyPhysicalTest.Repository
{
    public class VrmDailyPhysicalTestRepository : IVrmDailyPhysicalTest
    {
        private readonly AppDbContext _context;
        public VrmDailyPhysicalTestRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<VrmDailyPhysicalTestElementconfigDTO>> GetVrmDailyPhysicalTestElementconfigDDL(long BusinessUnitId)
        {
			try
			{
                var data = await (from config in _context.TblVrmDailyPhysicalTestElementconfigs
                                                  where config.IntBusinessUnitId == BusinessUnitId && config.IsActive == true
                                                  select new VrmDailyPhysicalTestElementconfigDTO
                                                  {
                                                      value = config.IntTestElementId,
                                                      label = config.StrTestElementName,
                                                      IntBusinessUnitId = config.IntBusinessUnitId,
                                                      IntUoMid = config.IntUoMid,
                                                      StrUoMname = config.StrUoMname,
                                                  }).ToListAsync();
                return data;
			}
			catch (Exception ex)
			{
				throw ex;
				
			}
        }

        
    }
}
