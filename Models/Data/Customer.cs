namespace HavitGridBug.Models.Data
{
    public class Customer
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
