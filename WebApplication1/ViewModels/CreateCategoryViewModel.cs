using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class CreateCategoryViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
