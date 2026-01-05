using Fiorello.ViewModels.Expert;

namespace Fiorello.Services.Interfaces
{
    public interface IExpertService
    {
        Task<IEnumerable<ExpertUIVM>> GetAllAsync();
        Task<IEnumerable<ExpertVM>> GetAllAdminAsync();
    }
}
