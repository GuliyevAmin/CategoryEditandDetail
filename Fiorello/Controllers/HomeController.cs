using System.Diagnostics;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Fiorello.ViewModels.Blog;
using Fiorello.ViewModels.Expert;
using Fiorello.ViewModels.Slider;
using Fiorello.ViewModels.SliderInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {
      private readonly ISliderService _sliderService;
      private readonly IBlogService _blogService;
      private readonly ISliderInfoService _sliderInfoService;
      private readonly IExpertService _expertService;

        public HomeController(ISliderInfoService sliderInfoService ,IBlogService blogService,ISliderService sliderService,IExpertService expertService)
        {
            _sliderService = sliderService;
            _blogService = blogService;
            _sliderInfoService = sliderInfoService;
            _expertService = expertService;

        }


        public async Task<IActionResult>  Index()
        {
            IEnumerable<SliderUIVM> sliders = await _sliderService.GetAllAsync();
            SliderInfoUIVM sliderInfo = await _sliderInfoService.GetInfoAsync();
            IEnumerable<BlogUIVM> blogs = await _blogService.GetAllAsync();
            IEnumerable<ExpertUIVM> experts = await _expertService.GetAllAsync();





            HomeVM model = new HomeVM
            {
                Sliders = sliders,
                SliderInfo = sliderInfo,
                Blogs = blogs.Take(3),
                Experts = experts
            };



            return View(model);
        }

       
    }
}
