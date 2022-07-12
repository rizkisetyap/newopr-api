using My_OPR.Data;
using My_OPR.Models.DocumentISO;
using Microsoft.EntityFrameworkCore;

namespace My_OPR.Repositories.Data.DokumenIso
{
    public class DocumentISORepository : GenericRepository<ApplicationDBContext, FileRegisteredIso, int>
    {
        public readonly ApplicationDBContext _context;
        public DocumentISORepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetByNpp(string? npp)
        {
            var employe = _context.Employees.Where(x => x.NPP == npp).FirstOrDefault();
            var service = _context.Services.Include(x => x.Group).Where(x => x.Id == employe.ServiceId).FirstOrDefault();
            var result =
                from Docis in _context.FileRegisteredIsos
                join DR in _context.DetailRegisters on Docis.DetailRegisterId equals DR.Id
                join RF in _context.RegisteredForms on DR.RegisteredFormId equals RF.Id
                join SVC in _context.Services on Docis.ServiceId equals SVC.Id
                join GRP in _context.Groups on SVC.GroupId equals GRP.Id
                join KD in _context.KategoriDocuments on RF.KategoriDocumentId equals KD.Id
                where GRP.Id == service!.GroupId && Docis.IsDelete == false
                select new
                {
                    Id = Docis.Id,
                    FileName = Docis.FileName,
                    FilePath = Docis.FilePath,
                    FormNumber = RF.FormNumber,
                    FormName = RF.Name,
                    CreateDate = Docis.CreateDate,
                    UpdateDate = Docis.UpdateDate,
                    DeleteDate = Docis.DeleteDate
                }
            ;

            return result;

        }
    }
}