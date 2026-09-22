using Ecommerce.Eunums;
namespace Ecommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public Status Status { get; set; }

        public string MainImage { get; set;  }
         public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
