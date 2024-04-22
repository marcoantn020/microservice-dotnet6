using AutoMapper;
using GeekShopping.ProductApi.Data.DTO;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MysqlContext _context;
        private IMapper _mapper;

        public ProductRepository(MysqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> FindAll()
        {
           var products = await _context.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> FindById(long id)
        {
            ProductModel product = await _context.Products
                .Where(product => product.Id == id)
                .FirstOrDefaultAsync() ?? new ProductModel();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Create(ProductDto product)
        {
            ProductModel productModel = _mapper.Map<ProductModel>(product);
            _context.Products.Add(productModel);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(productModel);
        }

        public async Task<ProductDto> Update(ProductDto product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id) ?? throw new Exception("Product not found.");
            _mapper.Map(product, existingProduct);
            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(existingProduct);
        }

        public async Task<bool> Delete(long id) 
        {
            try
            {
                ProductModel product = await _context.Products
                .Where(product => product.Id == id)
                .FirstOrDefaultAsync() ?? new ProductModel();

                if (product.Id < 1) return false;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            };
        }
    }
}
