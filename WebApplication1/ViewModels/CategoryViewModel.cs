using Ecommerce.Eunums;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
   
        public string Name { get; set; }
        public Status Status { get; set; }
    }

}
