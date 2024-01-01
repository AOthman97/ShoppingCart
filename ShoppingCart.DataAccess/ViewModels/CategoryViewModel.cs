using ShoppingCart.Models;

namespace ShoppingCart.DataAccess.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; } = new Category();
        public IEnumerable<Category> Categories { get; set;} = new List<Category>();
    }
}