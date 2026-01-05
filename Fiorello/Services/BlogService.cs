using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Blog;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogVM>> GetAllAdminAsync()
        {
            IEnumerable<BlogVM> blogs = await _context.Blogs
                .Include(b => b.BlogImages)
                .Select(b => new BlogVM
                {
                    Id = b.Id,
                    Title = b.Title,
                    CreatedDate = b.CreatedDate,
                    Description = b.Description,
                    Image = b.BlogImages.FirstOrDefault(i => i.IsMain).Image
                })
                .ToListAsync();
             return blogs;
        }

        public async Task<IEnumerable<BlogUIVM>> GetAllAsync()
        {
            IEnumerable<BlogUIVM> blogs = await _context.Blogs.
                Include(b => b.BlogImages).
                Select(b => new BlogUIVM
                {
                    Id = b.Id,
                    Title = b.Title,
                    CreatedDate = b.CreatedDate,
                    Description = b.Description,
                    Image = b.BlogImages.FirstOrDefault(i => i.IsMain).Image

                })
                . ToListAsync();
            return blogs;
        }

        public async Task<BlogDetailVM> GetById(int? id)
        {
            var blog = await _context.Blogs
                .Include(b => b.BlogImages)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null) return null;
            return new BlogDetailVM
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                TeacherName = blog.TeacherName,
                BlogImage = new BlogImageUIVM
                {
                    Image = blog.BlogImages.FirstOrDefault(bi => bi.IsMain)?.Image
                }
            };
        }
    }
}
