using System.ComponentModel.DataAnnotations;

namespace Fiorello.ViewModels.Category
{
    public class CategoryUpdateVM
    {
        [Required(ErrorMessage= "Category Cant Be Empty")]
        [MaxLength(20, ErrorMessage = "Category Name Max Length is 20")]
        public string Name { get; set; }
    }
}
