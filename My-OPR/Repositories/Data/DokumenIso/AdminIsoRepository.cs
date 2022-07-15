using My_OPR.Data;
using My_OPR.Models.DocumentISO;
using Microsoft.EntityFrameworkCore;

namespace My_OPR.Repositories.Data.DokumenIso
{
    public class AdminIsoRepository : GenericRepository<ApplicationDBContext, FileRegisteredIso, int>
    {
        private readonly ApplicationDBContext _context;
        public AdminIsoRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable GetKelompok()
        {

            var k = _context.Groups.Where(x => x.IsDelete == false).Select(x => new
            {
                Id = x.Id,
                Name = x.GroupName,
                Service = x.Services,
            });

            return k;
        }
        public IQueryable Unit(int serviceId)
        {
            var l = _context.Units.Where(x => x.ServiceId == serviceId && x.IsDelete == false);

            return l;
        }
        // Get File by units
        public IQueryable GetFiles(int UnitId)
        {
            var files = _context.FileRegisteredIsos
            .Include(x => x.DetailRegister)
            .Include(x => x.DetailRegister.RegisteredForm)
            .Where(x => x.IsDelete == false && x.DetailRegister.isActive == true && x.DetailRegister.IsDelete == false && x.DetailRegister.RegisteredForm.SubLayananId! == UnitId);

            return files;
        }
        public int Count(int GroupId, int ServiceId, int unitId)
        {
            var count = _context.FileRegisteredIsos.Include(x => x.DetailRegister)
            .Include(x => x.DetailRegister.RegisteredForm)
            .Where(x => x.IsDelete == false && x.DetailRegister.isActive == true && x.DetailRegister.RegisteredForm.GroupId == GroupId);
            if (ServiceId > 0)
            {
                count = count.Where(x => x.DetailRegister.RegisteredForm.ServiceId == ServiceId);
            }
            if (unitId > 0)
            {
                count = count.Where(x => x.DetailRegister.RegisteredForm.SubLayananId == unitId);
            }



            return count.Count();
        }



    }
}