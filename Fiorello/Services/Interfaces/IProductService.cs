using Fiorello.ViewModels.Product;

namespace Fiorello.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductUIVM>> GetAllAsync();
        Task<IEnumerable<ProductVM>> GetAllAdminAsync();
    }
}
