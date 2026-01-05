using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CategoryCreateVM model)
        {
            await _context.Categories.AddAsync(new Models.Category { Name = model.Name });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var data = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(data is not null)
            {
                _context.Categories.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoryVM>> GetAllAdminAsync()
        {
            var categories = await _context.Categories.Select(s => new CategoryVM
            {
                Id = s.Id,
                Name = s.Name,
                CreatedDate = s.CreatedDate
            }).ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<CategoryUIVM>> GetAllAsync()
        {
            var categories = await _context.Categories.Select(s => new CategoryUIVM
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();
            return categories;
        }

        public async Task<CategoryDetailVM> GetById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return new CategoryDetailVM
            {
                Id = category.Id,
                Name = category.Name,
                CreatedDate = category.CreatedDate
            };
        }

        public async Task<bool> IsExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<bool> IsExistExceptByIdAsync(int id, string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name.ToLower().Trim() == name.ToLower().Trim() && c.Id!=id);
        }

        public async Task UpdateAsync(int id, CategoryUpdateVM model)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is not null)
            {
                category.Name = model.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
