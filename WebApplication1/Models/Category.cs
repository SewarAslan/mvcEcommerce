using Ecommerce.Eunums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Category
    {
        public int Id { get;  set; }
        [Column(TypeName ="varchar(30)")]

        public string Name { get; set; }
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        public List<Product> Products { get; set; }

    }
}
