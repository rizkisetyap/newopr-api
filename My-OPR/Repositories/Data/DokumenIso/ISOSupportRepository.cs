using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.DocumentISO;

namespace My_OPR.Repositories.Data.DokumenIso
{
    public class ISOSupportRepository : GenericRepository<ApplicationDBContext, ISOSupport, int>
    {
        private readonly ApplicationDBContext _context;
        public ISOSupportRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public List<ISOSupport> GetAll()
        {
            return _context.ISOSupports.Where(x => x.IsDelete == false).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.ISOSupports.Find(id);
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
