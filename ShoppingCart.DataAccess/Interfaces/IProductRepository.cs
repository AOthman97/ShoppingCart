using ShoppingCart.Models;

namespace ShoppingCart.DataAccess.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product entity);
    }
}