using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.DocumentISO;

namespace My_OPR.Repositories.Data.DokumenIso
{
    public class AdminIsoRepository : GenericRepository<ApplicationDBContext, FileRegisteredIso, int>
    {
        private readonly ApplicationDBContext _context;
        public AdminIsoRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        #region Get Kelompok
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
        #endregion
        #region Get Unit Bt serviceId
        public IQueryable Unit(int serviceId)
        {
            var l = _context.Units.Where(x => x.ServiceId == serviceId && x.IsDelete == false);

            return l;
        }
        #endregion
        #region Get Dokumen by UnitId
        // Get File by units
        public IQueryable GetFiles(int UnitId)
        {
            var files = _context.FileRegisteredIsos
            .Include(x => x.DetailRegister)
            .Include(x => x.DetailRegister.RegisteredForm)
            .Where(x => x.IsDelete == false && x.DetailRegister.isActive == true && x.DetailRegister.IsDelete == false && x.DetailRegister.RegisteredForm.SubLayananId! == UnitId);

            return files;
        }
        #endregion
        #region Counting, Not implemented
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
        #endregion
        #region History Revisi
        public IQueryable History(int fileRegisterId)
        {
            var regId = _context.FileRegisteredIsos
                .Include(x => x.DetailRegister)
                .Include(x => x.DetailRegister.RegisteredForm)
                .Where(x => x.IsDelete == false && x.Id == fileRegisterId).Select(x => x.DetailRegister.RegisteredFormId).FirstOrDefault();
            var files = _context.FileRegisteredIsos
                .Include(x => x.DetailRegister)
                .Include(x => x.DetailRegister.RegisteredForm)
                .Where(x => x.DetailRegister.RegisteredFormId == regId).OrderBy(x => x.DetailRegister.Revisi);

            return files;
        }
        #endregion
        #region Incremental Static Regeneration
        public IQueryable FilesISR()
        {
            return _context.FileRegisteredIsos.Select(x => new
            {
                Id = x.Id,
                Path = x.FilePath,
                Name = x.FileName,
            });
        }
        #endregion

    }
}