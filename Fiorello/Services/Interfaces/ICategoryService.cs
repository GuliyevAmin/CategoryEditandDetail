using Fiorello.ViewModels.Category;

namespace Fiorello.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryUIVM>> GetAllAsync();
        Task<IEnumerable<CategoryVM>> GetAllAdminAsync();
        Task CreateAsync(CategoryCreateVM model);
        Task DeleteAsync(int? id);
        Task<CategoryDetailVM> GetById(int id);
        Task<bool> IsExistAsync(string name);
        Task<bool> IsExistExceptByIdAsync(int id,string name);
        Task UpdateAsync(int id, CategoryUpdateVM model);
    }
}
