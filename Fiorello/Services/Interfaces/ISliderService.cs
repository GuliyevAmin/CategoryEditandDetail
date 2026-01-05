using Fiorello.Models;
using Fiorello.ViewModels.Slider;

namespace Fiorello.Services.Interfaces
{
    public interface ISliderService
    {
        Task<IEnumerable<SliderUIVM>> GetAllAsync();
        Task<IEnumerable<SliderVM>> GetAllAdminAsync();
    }
}
