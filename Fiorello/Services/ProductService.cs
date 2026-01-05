using Fiorello.Data;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Product;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductVM>> GetAllAdminAsync()
        {
            var products = await _context.Products.Include(m => m.ProductImages).Select(p => new ProductVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
                Image = p.ProductImages.FirstOrDefault(m => m.IsMain).Image
            }).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<ProductUIVM>> GetAllAsync()
        {
            var products = await _context.Products.Include(m => m.ProductImages).Select(p => new ProductUIVM
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
                Image = p.ProductImages.FirstOrDefault(m => m.IsMain).Image
            }).ToListAsync();
            return products;
        }
    }
}
