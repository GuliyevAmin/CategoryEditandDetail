using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
