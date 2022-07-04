using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.DocumentISO;

namespace My_OPR.Repositories.Data.DokumenIso
{
    public class HistoryIsoRepository : GenericRepository<ApplicationDBContext, HistoryISO, int>
    {
        private readonly ApplicationDBContext _context;
        public HistoryIsoRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<HistoryISO> GetAll()
        {
            return _context.HistoryISOs.Where(x => x.IsDelete == false).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.HistoryISOs.Find(id);
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
