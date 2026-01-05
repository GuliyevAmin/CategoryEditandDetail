using Fiorello.Models;
using Fiorello.ViewModels.SliderInfo;

namespace Fiorello.Services.Interfaces
{
    public interface ISliderInfoService
    {
        Task<SliderInfoUIVM> GetInfoAsync();
        Task<SliderInfoVM> GetInfoAdminAsync();
    }
}
