using AngularETicaret.API.Dtos;
using AngularETicaret.Core.DBModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularETicaret.API.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(x=>x.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))//product icerisindeki productbrand ile productbrandclassının ıcındeki name esliyorum 
                 .ForMember(x => x.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                 .ForMember(x => x.PictureUrl, o => o.MapFrom<ProductUrlResolver>());//url tarafının kontrol edilme kısımlarını yaptık

        }
    }
}
