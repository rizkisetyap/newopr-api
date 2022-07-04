using My_OPR.Data;
using My_OPR.Models.Master;

namespace My_OPR.Repositories.Data
{
    public class LocationRepository : GenericRepository<ApplicationDBContext, OfficeLocation, int>
    {
        public readonly ApplicationDBContext _context;
        public LocationRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public List<OfficeLocation> GetAll()
        {
            return _context.officeLocations.ToList();
        }
    }
}
