using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class InstagramViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
