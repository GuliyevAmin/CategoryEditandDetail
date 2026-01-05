using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class ExpertViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
