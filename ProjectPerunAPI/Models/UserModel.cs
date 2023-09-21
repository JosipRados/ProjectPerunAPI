namespace ProjectPerunAPI.Models
{
    public class UserModel
    {
        public int? ID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int CreatedBy { get; set; }
        public decimal? HourPrice { get; set; }
        public bool Active { get; set; }

    }
}
