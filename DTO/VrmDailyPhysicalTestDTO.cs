using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VrmDailyPhysicalTest.DTO
{
    public class VrmDailyPhysicalTestDTO
    {
        public class VrmDailyPhysicalTestHeader
        {
            public long IntDailyPhysicalTestId { get; set; }
          
            public long? IntBusinessUnitId { get; set; }
            
            public long? IntShiftId { get; set; }
           
            
            public string? StrShiftName { get; set; }
           
            public long? IntVrmid { get; set; }
           
            public string? StrVrmname { get; set; }
            
            public long? IntItemTypeId { get; set; }
            
            public string? StrItemTypeName { get; set; }
           
            public TimeSpan? TmTime { get; set; }
           
            public DateTime? DteDate { get; set; }
           
            public decimal? NumInitialTime { get; set; }
           
            public decimal? NumFinalTime { get; set; }
            
            public string? StrRemark { get; set; }
         
            public bool? IsActive { get; set; }

            public List<VrmDailyPhysicalTestRow>? row { get; set; }
            

        }

        public class VrmDailyPhysicalTestElementconfigDTO
        {
            public long value { get; set; }
            public string? label { get; set; }
            public long? IntBusinessUnitId { get; set; }
            public long? IntUoMid { get; set; }
            public string? StrUoMname { get; set; }
        }

        public class VrmDailyPhysicalTestRow
        {
            public long? IntTestElementId { get; set; }
            
            public long? IntDailyPhysicalTestId { get; set; }
            
            public decimal? NumTestElementValue { get; set; }
           
            public bool? IsActive { get; set; }
           
        }
    }
}
