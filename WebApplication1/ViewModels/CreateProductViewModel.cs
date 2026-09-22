using Ecommerce.Eunums;
using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0.10,100000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        
        [Required]
        public Status Status { get; set; }
        
        [Required] 
        public IFormFile MainImage { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
