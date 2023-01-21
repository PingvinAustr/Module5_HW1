namespace Module5_HW1.Models
{
    public class Resource : Validation
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Year { get; set; }

        public string Color { get; set; } = null!;

        public string PantoneValue { get; set; } = null!;
    }
}
