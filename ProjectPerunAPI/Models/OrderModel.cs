namespace ProjectPerunAPI.Models
{
    public class OrderModel
    {
        public int? ID { get; set; }
        public int? ProjectID { get; set; }
        public int? OrderedQuantity { get; set; }
        public DateTime? DateOrdered { get; set; }
        public DateTime? DateFinal { get; set; }
        public string? Stage { get; set; }
        public bool? MaterialSeparated { get; set; }
        public bool? Finished { get; set; }
        public decimal? MaterialPrice { get; set; }
        public decimal? WorkerPrice { get; set; }
        public TimeSpan? ProductionTime { get; set; }
        public TimeSpan? FinishingTime { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int? UserID { get; set; }
    }
}
