using System.Runtime.Serialization;

namespace VrmDailyPhysicalTest.Helper
{
    public class MessageHelper
    {
        [DataMember]
        public string? Message { get; set; }
        public int statuscode { get; set; }
        public long Key { get; set; }
    }
}
