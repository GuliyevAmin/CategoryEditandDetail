using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Slider;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        public SliderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SliderVM>> GetAllAdminAsync()
        {
            IEnumerable<SliderVM> sliders = await _context.Sliders.
                Select(s => new SliderVM
                {
                    Image = s.Image
                })
                .ToListAsync();
            return sliders;
        }

        public async Task<IEnumerable<SliderUIVM>> GetAllAsync()
        {
            IEnumerable<SliderUIVM> sliders = await _context.Sliders.
                Select(s => new SliderUIVM
                {
                    Image = s.Image
                })
                .ToListAsync();
            return sliders;
        }
    }
}
