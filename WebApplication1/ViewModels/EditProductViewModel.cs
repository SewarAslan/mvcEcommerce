using Ecommerce.Eunums;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0.10, 100000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public double Rate { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string? CurrentImage { get; set; }

        public IFormFile? MainImage { get; set; }
    }
}