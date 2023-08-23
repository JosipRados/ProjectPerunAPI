using Microsoft.Extensions.Configuration.UserSecrets;

namespace ProjectPerunAPI.Models
{
    public class BatchDataModel
    {
        public int ID { get; set; }
        public int BatchNumber { get; set; }
        public string? Sender { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int UserID { get; set; }
    }
}
