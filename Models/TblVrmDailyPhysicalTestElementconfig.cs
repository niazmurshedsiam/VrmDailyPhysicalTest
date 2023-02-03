using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VrmDailyPhysicalTest.Models
{
    [Table("tblVrmDailyPhysicalTestElementconfig")]
    public partial class TblVrmDailyPhysicalTestElementconfig
    {
        [Key]
        [Column("intTestElementId")]
        public long IntTestElementId { get; set; }
        [Column("intBusinessUnitId")]
        public long? IntBusinessUnitId { get; set; }
        [Column("strTestElementName")]
        [StringLength(150)]
        public string? StrTestElementName { get; set; }
        [Column("intUoMId")]
        public long? IntUoMid { get; set; }
        [Column("strUoMName")]
        [StringLength(150)]
        public string? StrUoMname { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
    }
}
