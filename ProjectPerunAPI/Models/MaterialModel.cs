namespace ProjectPerunAPI.Models
{
    public class MaterialModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? TransactionType { get; set; }

        public int PackageQuantity { get; set; }
        public int CurrentQuantity { get; set; }
        public decimal Price { get; set; }
        public int? ElementID { get; set; }
        public string? Type { get; set; }
        public int WarehouseID { get; set; }
        public DateTime? LastChange { get; set; }
        public int UserID { get; set; }
        public DateTime? TimeStamp { get; set; }
        public bool Reserved { get; set; }
        public bool OnProject { get; set; }
        public int? BatchID { get; set; }
        public int? ImportBatchNumber { get; set;}

    }
}
