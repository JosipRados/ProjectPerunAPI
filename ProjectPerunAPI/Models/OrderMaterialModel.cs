using Microsoft.Extensions.Configuration.UserSecrets;

namespace ProjectPerunAPI.Models
{
    public class OrderMaterialModel
    {
        public int? ID { get; set; }
        public int? OrderID { get; set; }
        public int? StorageID { get; set; }
        public int? StorageNumber { get; set; }
        public int? Quantity { get; set; }
        public string? Type { get; set; }
        public string? Department { get; set; }
        public bool? Spent { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int? UserID { get; set; } 
    }
}
