using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.Master;

namespace My_OPR.Repositories.Data
{
    public class PositionRepository : GenericRepository<ApplicationDBContext, Position, int>
    {
        private readonly ApplicationDBContext _context;
        public PositionRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<Position> GetAll()
        {
            return _context.Positions.Where(x=>x.IsDelete == false).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.Positions.Find(id);
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
