using LukeRamsayWebAPI.Models;
using LukeRamsayWebAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace LukeRamsayWebAPI.services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
    }

    public class ProductService : IProductService
    {
        private readonly ECommerceContext _context;

        public ProductService(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

    }
}