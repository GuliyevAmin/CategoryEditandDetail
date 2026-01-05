using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllAdminAsync();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var isExist = await _categoryService.IsExistAsync(model.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This category name is already exist");
                return View(model);
            }
            await _categoryService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var data = await _categoryService.GetById(id.Value);
            if (data is null) return NotFound();
            await _categoryService.DeleteAsync(data.Id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            var data = await _categoryService.GetById(id.Value);
            if (data is null) return NotFound();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();
            var data = await _categoryService.GetById(id.Value);
            if (data is null) return NotFound();
            return View(new CategoryUpdateVM { Name = data.Name });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, CategoryUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (id is null) return BadRequest();
            var data = await _categoryService.GetById(id.Value);
            if (data is null) return NotFound();
            var isExist = await _categoryService.IsExistExceptByIdAsync(id.Value, model.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This category name is already exist");
                return View(model);
            }
            await _categoryService.UpdateAsync(data.Id, model);
            return RedirectToAction(nameof(Index));
        }
    }
}
