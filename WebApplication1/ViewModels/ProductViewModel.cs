using Ecommerce.Eunums;

namespace Ecommerce.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string MainImage { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public Status Status { get; set; }
    }
}