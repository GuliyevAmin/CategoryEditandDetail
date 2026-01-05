
using Fiorello.ViewModels.Blog;

namespace Fiorello.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogUIVM>> GetAllAsync();
        Task<BlogDetailVM> GetById(int? id);

        Task<IEnumerable<BlogVM>> GetAllAdminAsync();
    }
}
