namespace ProjectPerunAPI.Models
{
    public class WarehouseDataModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int UserID { get; set; }
    }
}
