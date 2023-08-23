namespace ProjectPerunAPI.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Company { get; set; }
        public string? Description { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int UserID { get; set; }
        public bool Active { get; set; }
    }
}
