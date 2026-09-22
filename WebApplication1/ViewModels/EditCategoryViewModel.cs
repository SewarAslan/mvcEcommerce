using System.ComponentModel.DataAnnotations;
using Ecommerce.Eunums;
namespace Ecommerce.ViewModels
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; } 
        public Status Status { get; set; }
     }
}
