using AutoMapper;
using GeekShopping.ProductApi.Data.DTO;
using GeekShopping.ProductApi.Model;

namespace GeekShopping.ProductApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductModel, ProductDto>();
                config.CreateMap<ProductDto, ProductModel>();
            });

            return mappingConfig;
        }
    }
}
