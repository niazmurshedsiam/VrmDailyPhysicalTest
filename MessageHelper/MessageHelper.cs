using System.Runtime.Serialization;

namespace VrmDailyPhysicalTest.MessageHelper
{
    public class MessageHelper
    {

        [DataMember]
        public string? Message { get; set; }
        public int statuscode { get; set; }
        public long Key { get; set; }

    }
}
