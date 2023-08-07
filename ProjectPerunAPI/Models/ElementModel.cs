namespace ProjectPerunAPI.Models
{
    public class ElementModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? ElementType { get; set; }
        public string? Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserID { get; set; }

        ElementModel() { }


    }
}
