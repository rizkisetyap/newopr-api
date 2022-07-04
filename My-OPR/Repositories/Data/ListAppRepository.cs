using My_OPR.Data;
using My_OPR.Models.Master;
using Microsoft.EntityFrameworkCore;

namespace My_OPR.Repositories.Data
{
    public class ListAppRepository : GenericRepository<ApplicationDBContext, ListApp, int>
    {
        private readonly ApplicationDBContext _context;
        public ListAppRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ListApp> GetAll()
        {
            return _context.ListApps.Where(x => x.IsDelete == false).OrderByDescending(x => x.CreateDate).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.ListApps.Find(id);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Entry(data).State = EntityState.Modified;
            }
            var result = _context.SaveChanges();
            return result;
        }
    }
}