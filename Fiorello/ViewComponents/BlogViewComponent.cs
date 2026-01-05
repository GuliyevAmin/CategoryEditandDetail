using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
