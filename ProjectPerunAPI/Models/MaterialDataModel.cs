namespace ProjectPerunAPI.Models
{
    public class MaterialDataModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? MaterialType { get; set; }
        public string? Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserID { get; set; }
        public bool Active { get; set; }

        MaterialDataModel() { }


    }
}
