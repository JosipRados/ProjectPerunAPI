namespace ProjectPerunAPI.Models
{
    public class ProjectMaterialsModel
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int MaterialID { get; set; }
        public int Quantity { get; set; }
        public string? MaterialType { get; set; }
        public string? Department { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int UserID { get; set; }
        public string? MaterialCode { get; set; }

    }
}
