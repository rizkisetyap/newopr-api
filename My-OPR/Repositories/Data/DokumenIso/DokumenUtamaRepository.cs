using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Lib;
using My_OPR.Models.DocumentISO;
using My_OPR.ViewModels;
namespace My_OPR.Repositories.Data.DokumenIso
{
    public class DokumenUtamaRepository : GenericRepository<ApplicationDBContext, ISOCore, int>
    {
        public readonly ApplicationDBContext _context;
        public DokumenUtamaRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        #region Dokumen utama upload /insert
        public int UploadDokumenUtama(UploadDokumenUtamaVM model)
        {
            try
            {
                // Mapping
                //
                ISOCore dokumen = new ISOCore();
                dokumen.Name = model.ISOCore.Name;
                dokumen.JenisDocumentId = model.ISOCore.JenisDocumentId;
                dokumen.GroupId = model.ISOCore.GroupId;
                dokumen.CreatedDate = DateTime.Now;

                var exist = _context.ISOCores.Any(x => x.JenisDocumentId == model.ISOCore.JenisDocumentId && x.GroupId == model.ISOCore.GroupId && x.IsDelete == false);
                if (exist)
                {
                    throw new Exception("Confict data already exist");
                }

                _context.Add(dokumen);
                _context.SaveChanges();
                var DokumenId = dokumen.Id;
                var HI = new HistoryISO();
                var KategoriDocument = (
                    from KD in _context.KategoriDocuments
                    join JD in _context.JenisDocuments
                    on KD.Id equals JD.KategoriDokumenId
                    where JD.Id == dokumen.JenisDocumentId
                    select KD

                ).FirstOrDefault();
                HI.ISOCoreId = DokumenId;
                HI.Revision = 0;
                HI.CreateDate = dokumen.CreatedDate;
                var kelompok = _context.ISOCores.Include(x => x.Group).Where(x => x.Id == DokumenId).Select(x => x.Group.GroupName).FirstOrDefault();
                _context.Add(HI);
                if (model.FileIso != null)
                {
                    var path = Path.Combine("public", "Document ISO", KategoriDocument.Name, kelompok);
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
            catch (System.Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        #endregion
        #region Dokumen Utama Get By Group
        public IQueryable GetByGroup(int GroupId)
        {
            try
            {
                var result = _context.HistoryISOs
                    .Include(x => x.ISOCore)
                    .Include(x => x.ISOCore.Group)
                    .Include(x => x.ISOCore.JenisDocument)
                    .Where(x => x.IsDelete == false && x.ISOCore.GroupId == GroupId).Select(x => new
                    {
                        Id = x.Id,
                        Name = x.ISOCore.Name,
                        Revisi = x.Revision,
                        Path = x.ISOCore.FilePath,
                        CreateDate = x.ISOCore.CreatedDate,
                        UpdateDate = x.ISOCore.UpdatedDate,
                        GroupId = x.ISOCore.GroupId,
                        IsoCoreId = x.ISOCoreId
                    }).OrderByDescending(x => x.UpdateDate).ThenByDescending(x => x.CreateDate);
                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        #endregion
        #region update dokumen utama
        public ISOCore Update(UpdateIsoCoreVM model, int Id)
        {
            var isoCore = _context.ISOCores
                .Where(x => x.IsDelete == false && x.Id == Id).FirstOrDefault();
            var history = _context.HistoryISOs.Where(x => x.IsDelete == false && x.ISOCoreId == Id).FirstOrDefault();
            if (isoCore == null && history == null)
            {
                throw new Exception("Item Not Found");
            }
            isoCore.IsDelete = true;
            history.IsDelete = true;
            _context.Entry(isoCore).State = EntityState.Modified;
            _context.Entry(history).State = EntityState.Modified;
            _context.SaveChanges();
            ISOCore dokumenUtamaBaru = new ISOCore();
            dokumenUtamaBaru.CreatedDate = isoCore.CreatedDate;
            dokumenUtamaBaru.UpdatedDate = DateTime.Now;
            dokumenUtamaBaru.IsDelete = false;
            dokumenUtamaBaru.JenisDocumentId = isoCore.JenisDocumentId;
            dokumenUtamaBaru.GroupId = isoCore.GroupId;
            dokumenUtamaBaru.FilePath = isoCore.FilePath;
            dokumenUtamaBaru.Name = model.name;
            _context.Add(dokumenUtamaBaru);
            _context.SaveChanges();
            HistoryISO newHistory = new HistoryISO();
            newHistory.ISOCoreId = dokumenUtamaBaru.Id;
            newHistory.CreateDate = dokumenUtamaBaru.CreatedDate;
            newHistory.UpdateDate = DateTime.Now;
            newHistory.IsDelete = false;
            newHistory.Revision = history.Revision + 1;

            _context.Add(newHistory);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            var data = _context.ISOCores
                .Include(x => x.JenisDocument)
                .Include(x => x.JenisDocument.KategoriDokumen)
                .Include(x => x.Group)
                .Where(x => x.IsDelete == false && x.Id == dokumenUtamaBaru.Id).Select(x => new
                {
                    Kategori = x.JenisDocument.KategoriDokumen.Name,
                    Group = x.Group.GroupName
                }).FirstOrDefault();

            if (model.File != null)
            {
                var path = Path.Combine("public", "Document ISO", data.Kategori, data.Group);
                var isDirExist = System.IO.Directory.Exists(path);
                if (!isDirExist)
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                var base64 = model.File.base64str.Substring(model.File.base64str.IndexOf(',') + 1);
                Byte[] bytes = Convert.FromBase64String(base64);
                var fileName = dokumenUtamaBaru.Name + "_REV_" + newHistory.Revision;
                var filepath = UploadLib.UploadContent(bytes, fileName, path, model.File.extension);
                dokumenUtamaBaru.FilePath = filepath;


            }
            _context.Entry(dokumenUtamaBaru).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return dokumenUtamaBaru;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}