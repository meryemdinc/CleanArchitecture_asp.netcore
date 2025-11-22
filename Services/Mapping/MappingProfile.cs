using App.Repositories.Products;
using App.Services.Products;
using AutoMapper;


namespace App.Services.Mapping
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();//Product'ı Product Dto'ya dönüştür,
                                                         //ReverseMap() ile tersi de mümkün olsun
        }
    }
}
