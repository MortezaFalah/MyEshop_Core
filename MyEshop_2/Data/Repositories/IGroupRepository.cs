using MyEshop_2.Models;

namespace MyEshop_2.Data.Repositories
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();

        IEnumerable<ShowGroupViewModel> GetGroupForSow();
    }



    public class GroupRepository : IGroupRepository
    {

        private MyEshopContext2 _context;
        public GroupRepository(MyEshopContext2 context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<ShowGroupViewModel> GetGroupForSow()
        {
             return _context.Categories.
                Select(v =>
                   new ShowGroupViewModel()
                   {
                       GroupId = v.id,
                       Name = v.name,
                       ProductCount = _context.categoryToProducts.Where(r => r.CategoryId == v.id).Count()
                   }

                );
        }
    }

}
