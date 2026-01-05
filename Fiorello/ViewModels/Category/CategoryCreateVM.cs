using System.ComponentModel.DataAnnotations;

namespace Fiorello.ViewModels.Category
{
    public class CategoryCreateVM
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
