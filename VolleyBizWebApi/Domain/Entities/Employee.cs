namespace VolleyBizWebApi.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Dob { get; set; }
        public int MartialStatus { get; set; }
        public string? Mobile { get; set; }
        public int Gender { get; set; }
        public string? Image { get; set; }
    }
}
