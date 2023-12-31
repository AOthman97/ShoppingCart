using ShoppingCart.DataAccess.Data;
using ShoppingCart.DataAccess.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product entity)
        {
            var Product = _context.Products.FirstOrDefault(x => x.Id == entity.Id);

            if (Product != null)
            {
                Product.Name = entity.Name;
                Product.Price = entity.Price;
                Product.Discription = entity.Discription;

                if(entity.ImageUrl != null)
                    Product.ImageUrl = entity.ImageUrl;
            }
        }
    }
}