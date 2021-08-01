using AngularETicaret.Core.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularETicaret.Core.Specifications
{
   public class ProductWithFiltersForCountSpecification:BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productSpecParams )
             :base(x=> (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))//arama yapıyorum
             &&
            ( !productSpecParams.BrandId.HasValue|| x.ProductBrandId== productSpecParams.BrandId)
             &&
            (!productSpecParams.TypeId.HasValue|| x.ProductTypeId== productSpecParams.TypeId)//burada baseden direk sorgulama yaptırabiliyoruz
        )
        {

        }
    }
}
