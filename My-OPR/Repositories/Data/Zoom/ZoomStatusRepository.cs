using My_OPR.Data;
using My_OPR.Models.ZoomScheduler;
using Microsoft.EntityFrameworkCore;

namespace My_OPR.Repositories.Data
{
    public class ZoomStatusRepository : GenericRepository<ApplicationDBContext, ZoomStatus, int>
    {
        private readonly ApplicationDBContext _context;
        public ZoomStatusRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ZoomStatus> GetAll()
        {
            return _context.ZoomStatuses.Where(x => x.IsDelete == false).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.ZoomStatuses.Find(id);
            if( data != null)
            {
                data.IsDelete = true;
                _context.Entry(data).State = EntityState.Modified;
            }
            var result = _context.SaveChanges();
            return result;
        }
    }
}