using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        public  async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
