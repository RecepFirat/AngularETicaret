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
        public ProductsWithProductTypeAndBrandsSpecification(string sort,int? brandId,int? typeId)
            :base(x=>!brandId.HasValue|| x.ProductBrandId==brandId
             &&
            (!typeId.HasValue|| x.ProductTypeId==typeId)//burada baseden direk sorgulama yaptırabiliyoruz
        )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);

            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
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
