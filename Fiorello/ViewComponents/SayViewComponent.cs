using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class SayViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
