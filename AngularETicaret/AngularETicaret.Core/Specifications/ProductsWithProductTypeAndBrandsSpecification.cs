using AngularETicaret.Core.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularETicaret.Core.Specifications
{
    public class ProductsWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandsSpecification(ProductSpecParams productSpecParams )
            :base(x=>(string.IsNullOrWhiteSpace(productSpecParams.Search)|| x.Name.ToLower().Contains(productSpecParams.Search))&&
            (!productSpecParams.BrandId.HasValue|| x.ProductBrandId== productSpecParams.BrandId)
             &&
            (!productSpecParams.TypeId.HasValue|| x.ProductTypeId== productSpecParams.TypeId)//burada baseden direk sorgulama yaptırabiliyoruz
        )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);

            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);
            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
            AddOrderBy(x => x.Name);
        }
        public ProductsWithProductTypeAndBrandsSpecification(int id):base(x=>x.Id==id)
        {//yukarıdaki ıd ye uygun bi sekilde getir diyorum
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
