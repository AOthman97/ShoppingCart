using ShoppingCart.DataAccess.Data;
using ShoppingCart.DataAccess.Interfaces;

namespace ShoppingCart.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
        }

        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}