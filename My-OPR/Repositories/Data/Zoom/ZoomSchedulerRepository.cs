

using My_OPR.Data;
using My_OPR.Models.ZoomScheduler;
using Microsoft.EntityFrameworkCore;

namespace My_OPR.Repositories.Data.Zoom
{
    public class ZoomSchedulerRepository : GenericRepository<ApplicationDBContext, Scheduler, int>
    {
        private readonly ApplicationDBContext _context;
        public ZoomSchedulerRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<Scheduler> GetAll()
        {
            return _context.Schedulers.Include(x => x.ZoomStatus).Include(x => x.ZoomModel).Include(x => x.Employee).Where(x => x.IsDelete == false).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.Schedulers.Find(id);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Entry(data).State = EntityState.Modified;
            }
            var result = _context.SaveChanges();
            return result;
        }
        public override IEnumerable<Scheduler> Get()
        {
            return _context.Schedulers.Include(x => x.ZoomModel).Include(x => x.Employee).Include(x => x.ZoomStatus).OrderBy(x => x.EndDate);
        }
        public int Delete(int id)
        {
            var schedule = _context.Schedulers.FirstOrDefault(x => x.Id == id);
            if (schedule == null)
            {
                return 404;
            }
            _context.Remove<Scheduler>(schedule);

            return _context.SaveChanges();

        }
    }
}