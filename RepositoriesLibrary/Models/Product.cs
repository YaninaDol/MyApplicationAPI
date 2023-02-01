namespace RepositoriesLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Model { get; set; } = null!;

        public double Price { get; set; }

        public int? CategoryId { get; set; }

        public string? Image { get; set; }

        public bool? Visible { get; set; }

        public int? Capacity { get; set; }
        public int? Sold { get; set; }
        public int? Popular { get; set; }

        public virtual Category? Category { get; set; }


    }
}