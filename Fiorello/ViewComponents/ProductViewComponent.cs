using Fiorello.Services;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Category;
using Fiorello.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public ProductViewComponent(ICategoryService categoryService,IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;   
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            var products = await _productService.GetAllAsync();

            ProductVMVC model = new ProductVMVC()
            {
                Categories = categories,
                Products = products
            };

            return View(model);
        }
    }
    public class ProductVMVC
    {
        public IEnumerable<CategoryUIVM> Categories { get; set; }
        public IEnumerable<ProductUIVM> Products { get; set; }
    }
}
