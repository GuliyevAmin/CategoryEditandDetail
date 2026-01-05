using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.SliderInfo;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class SliderInfoService : ISliderInfoService
    {
        private readonly AppDbContext _context;
        public SliderInfoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SliderInfoVM> GetInfoAdminAsync()
        {
            var sliderInfo = await _context.SliderInfos.
                Select(si => new SliderInfoVM
                {
                    Title = si.Title,
                    Description = si.Description,
                    SignatureImage = si.SignatureImage
                })
                .FirstOrDefaultAsync();
            return sliderInfo;
        }

        public async Task<SliderInfoUIVM> GetInfoAsync()
        {
            var sliderInfo = await _context.SliderInfos.
                Select(si => new SliderInfoUIVM
                {
                    Title = si.Title,
                    Description = si.Description,
                    SignatureImage = si.SignatureImage
                })
                .FirstOrDefaultAsync();
            return sliderInfo;
        }
    }
}
