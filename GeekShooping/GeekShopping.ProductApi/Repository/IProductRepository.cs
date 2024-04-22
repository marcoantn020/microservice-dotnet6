using GeekShopping.ProductApi.Data.DTO;

namespace GeekShopping.ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> FindAll();
        Task<ProductDto> FindById(long id);
        Task<ProductDto> Create(ProductDto product);
        Task<ProductDto> Update(ProductDto product);
        Task<bool> Delete(long id);
    }
}
