using System.ComponentModel.DataAnnotations.Schema;

namespace AngularETicaret.API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}
