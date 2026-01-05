using Fiorello.Models;
using Fiorello.ViewModels.Blog;
using Fiorello.ViewModels.Expert;
using Fiorello.ViewModels.Slider;
using Fiorello.ViewModels.SliderInfo;

namespace Fiorello.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<SliderUIVM> Sliders { get; set; }
        public SliderInfoUIVM SliderInfo { get; set; }
        public IEnumerable<BlogUIVM> Blogs { get; set; }

        public IEnumerable<ExpertUIVM> Experts { get; set; }

    }
}
