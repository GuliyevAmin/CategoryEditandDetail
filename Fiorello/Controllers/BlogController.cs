using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<BlogUIVM> blogs = await _blogService.GetAllAsync();
            return View(blogs);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            BlogDetailVM blog = await _blogService.GetById(id);
            if (blog == null) return NotFound();
            return View(blog);

        }
    }
}
