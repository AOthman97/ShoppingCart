using ShoppingCart.DataAccess.Data;
using ShoppingCart.DataAccess.Interfaces;
using ShoppingCart.Models;

namespace ShoppingCart.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category entity)
        {
            var Category = _context.Categories.FirstOrDefault(x => x.Id == entity.Id);

            if(Category != null)
            {
                Category.Name = entity.Name;
                Category.DisplayOrder = entity.DisplayOrder;
            }
        }
    }
}