using ShoppingCart.Models;

namespace ShoppingCart.DataAccess.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category entity);
    }
}