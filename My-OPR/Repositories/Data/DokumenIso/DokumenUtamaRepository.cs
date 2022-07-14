using My_OPR.Models.DocumentISO;
using My_OPR.Data;
using Microsoft.EntityFrameworkCore;
using My_OPR.ViewModels;
using My_OPR.Lib;
namespace My_OPR.Repositories.Data.DokumenIso
{
    public class DokumenUtamaRepository : GenericRepository<ApplicationDBContext, ISOCore, int>
    {
        public readonly ApplicationDBContext _context;
        public DokumenUtamaRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }


        public int UploadDokumenUtama(UploadDokumenUtamaVM model)
        {
            try
            {
                ISOCore dokumen = new ISOCore();
                dokumen.Name = model.ISOCore.Name;
                dokumen.JenisDokumenId = model.ISOCore.JenisDokumenId;
                dokumen.UnitId = model.ISOCore.UnitId;

                _context.Add(dokumen);
                _context.SaveChanges();
                var DokumenId = dokumen.Id;
                var HI = new HistoryISO();
                var Units = _context.Units.Where(x => x.Id == dokumen.UnitId).FirstOrDefault();
                var services = _context.Services
                .Include(x => x.Group)
                .Where(x => x.Id == Units.ServiceId).FirstOrDefault();
                var KategoriDocument = (
                    from KD in _context.KategoriDocuments
                    join JD in _context.JenisDocuments
                    on KD.Id equals JD.KategoriDokumenId
                    where JD.Id == dokumen.JenisDokumenId
                    select KD

                ).FirstOrDefault();
                HI.ISOCoreId = DokumenId;
                HI.Revision = 0;
                _context.Add(HI);
                if (model.FileIso != null)
                {
                    var path = Path.Combine("public", "Document ISO", KategoriDocument.Name, services.Group.GroupName, services.Name, Units.Name);
                    var isDirExist = System.IO.Directory.Exists(path);
                    if (!isDirExist)
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    var base64 = model.FileIso.base64str.Substring(model.FileIso.base64str.IndexOf(',') + 1);
                    Byte[] bytes = Convert.FromBase64String(base64);
                    var fileName = dokumen.Name + "_REV_" + HI.Revision;
                    var filepath = UploadLib.UploadContent(bytes, fileName, path, model.FileIso.extension);

                    dokumen.FilePath = filepath;
                    _context.Entry(dokumen).State = EntityState.Modified;
                    return _context.SaveChanges();


                }
                return 0;
            }
            catch (System.Exception)
            {

                throw new Exception("Request Error");
            }

        }

    }
}