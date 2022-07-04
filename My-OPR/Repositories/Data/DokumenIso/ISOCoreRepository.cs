using My_OPR.Data;
using My_OPR.Models.DocumentISO;
using My_OPR.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using My_OPR.ViewModels;
using My_OPR.Lib;
namespace My_OPR.Repositories.Data.DokumenIso
{
    public class ISOCoreRepository : GenericRepository<ApplicationDBContext, ISOCore, int>
    {
        private readonly ApplicationDBContext _context;
        public ISOCoreRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<ISOCore> GetAll()
        {
            return _context.ISOCores.Where(x => x.IsDelete == false).ToList();
        }

        public int SoftDelete(int id)
        {
            var data = _context.ISOCores.Find(id);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Entry(data).State = EntityState.Modified;
            }
            var result = _context.SaveChanges();
            return result;
        }
        public int InsertDocument(IsoCoreVM model)
        {
            var IsoDoc = model.ISOCore;
            if (IsoDoc == null)
            {
                return 400;
            }
            try
            {
                int ServiceId = model.ServiceId;
                var Service = _context.Services.Include(s => s.Group).Where(s => s.Id == ServiceId).FirstOrDefault();
                _context.ISOCores.Add(IsoDoc);
                _context.SaveChanges();
                var docId = IsoDoc.Id;
                var Doc = IsoDoc;
                string FilePath = "";
                if (model.file != null)
                {
                    var path = Path.Combine("public", "DocumentISO", "IsoCore");
                    bool isDirExist = System.IO.Directory.Exists(path);
                    if (!isDirExist)
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    var base64 = model.file.base64str.Substring(model.file.base64str.IndexOf(',') + 1);
                    Byte[] bytes = Convert.FromBase64String(base64);
                    FilePath = UploadLib.UploadContent(bytes, model.file.name, path, model.file.extension);

                    IsoDoc.FilePath = FilePath;
                    _context.SaveChanges();
                }
                return 200;
            }
            catch (System.Exception)
            {

                return 500;
            }
        }
    }
}
