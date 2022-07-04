using My_OPR.Models.ZoomScheduler;
using My_OPR.Data;
using Microsoft.EntityFrameworkCore;
namespace My_OPR.Repositories.Data.Zoom
{
    public class ZoomRepository : GenericRepository<ApplicationDBContext, Models.ZoomScheduler.ZoomModel, int>
    {
        private readonly ApplicationDBContext _context;
        public ZoomRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ZoomModel> GetAll()
        {
            return _context.Zooms.Where(x => x.IsDelete == false).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.Zooms.Find(id);
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