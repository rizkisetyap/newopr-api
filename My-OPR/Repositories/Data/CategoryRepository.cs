using My_OPR.Data;
using My_OPR.Models.Master;

namespace My_OPR.Repositories.Data
{
    public class CategoryRepository : GenericRepository<ApplicationDBContext, Category, int>
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public int SoftDelete(int id)
        {
            var data = _context.Categories.Find(id);

            if (data != null)
            {
                data.IsDelete = true;
            }
            var result = _context.SaveChanges();
            return result;
        }

        public List<Category> GetAll()
        {
            var result = _context.Categories.Where(x => x.IsDelete == false).ToList();
            return result;
        }

    }
}
