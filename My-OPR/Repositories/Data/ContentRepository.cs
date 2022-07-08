using My_OPR.Data;
using My_OPR.Models.Transaction;
using Microsoft.EntityFrameworkCore;
using My_OPR.Lib;
using My_OPR.ViewModels;
namespace My_OPR.Repositories.Data
{
    public class ContentRepository : GenericRepository<ApplicationDBContext, Content, int>
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _webHostBuilder;
        public ContentRepository(ApplicationDBContext context, IWebHostEnvironment webHostBuilder) : base(context)
        {
            _context = context;
            _webHostBuilder = webHostBuilder;
        }

        public int SoftDelete(int id)
        {
            var data = _context.Contents.Find(id);

            if (data != null)
            {
                data.IsDelete = true;
            }
            var result = _context.SaveChanges();
            return result;
        }

        public List<Content> GetAll()
        {
            return _context.Contents.Where(x => x.IsDelete == false).ToList();
        }

        public override IEnumerable<Content> Get()
        {
            return _context.Contents.Include(_context => _context.Category);
        }
        public override Content Get(int key)
        {
            return _context.Contents.Where(x => x.Id == key).Include(x => x.Category).FirstOrDefault();
        }
        public Content UpdateContent(ContentVM model)
        {
            if (model.content == null)
            {
                throw new ArgumentNullException("content is null");
            }

            try
            {
                Content content = model.content;
                _context.Entry(content).State = EntityState.Modified;
                string imgPath;
                string filePath;
                _context.SaveChanges();
                if (model.fileData.file != null)
                {
                    var path = Path.Combine("public", "upload", "content", "file");
                    var base64 = model.fileData.file.base64str;
                    base64 = base64!.Substring(base64.IndexOf(',') + 1);
                    Byte[] bytes = Convert.FromBase64String(base64);
                    var fileName = "File Konten - " + content.Id;
                    filePath = UploadLib.UploadContent(bytes, fileName, path, model.fileData!.file!.extension!);
                    content.PathContent = filePath;
                    _context.SaveChanges();
                }
                if (model.fileData.image != null)
                {
                    var path = Path.Combine("public", "upload", "content", "images");
                    var base64 = model.fileData.image.base64str;
                    base64 = base64!.Substring(base64.IndexOf(',') + 1);
                    Byte[] bytes = Convert.FromBase64String(base64);
                    var fileName = "Image Konten - " + content.Id;
                    imgPath = UploadLib.UploadContent(bytes, fileName, path, model.fileData!.image!.extension!);
                    content.PathImage = imgPath;
                    _context.SaveChanges();
                }
                return model.content;
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        public Content InsertContent(ContentVM model)
        {
            if (model.content == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                _context.Contents.Add(model.content);
                _context.SaveChanges();
                var id = model.content.Id;
                Content content = model.content;
                string imgPath = "";
                string filePath = "";
                if (model.fileData.file != null)
                {
                    var path = Path.Combine("public", "upload", "content", "file");
                    var base64 = model.fileData.file.base64str;
                    base64 = base64!.Substring(base64.IndexOf(',') + 1);
                    Byte[] bytes = Convert.FromBase64String(base64);
                    var fileName = "File Konten - " + id;
                    filePath = UploadLib.UploadContent(bytes, fileName, path, model.fileData!.file!.extension!);
                    content.PathContent = filePath;
                    _context.Entry(model.content).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                if (model.fileData.image != null)
                {
                    var path = Path.Combine("public", "upload", "content", "images");
                    var base64 = model.fileData.image!.base64str!;
                    base64 = base64.Substring(base64.IndexOf(',') + 1);
                    Byte[] bytes = Convert.FromBase64String(base64);
                    var fileName = "Image Konten - " + id;
                    imgPath = UploadLib.UploadContent(bytes, fileName, path, model.fileData!.image!.extension!);

                    content.PathImage = imgPath;

                    _context.Entry(model.content).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return content;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
