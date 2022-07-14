using My_OPR.Repositories.Interface;
using My_OPR.Data;
using My_OPR.Models.DocumentISO;
using Microsoft.EntityFrameworkCore;
namespace My_OPR.Repositories.Data.DokumenIso
{
    public class JenisDokumenRepository : GenericRepository<ApplicationDBContext, JenisDocument, int>
    {
        public readonly ApplicationDBContext _context;
        public JenisDokumenRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public List<JenisDocument> GetAll()
        {
            return _context.JenisDocuments.Where(x => x.IsDelete == false).ToList();
        }
        public int SoftDelete(int Id)
        {
            var data = _context.JenisDocuments.Where(x => x.Id == Id).FirstOrDefault();
            if (data == null)
            {
                throw new ArgumentNullException("Item not found");
            }
            data.IsDelete = true;
            _context.Entry(data).State = EntityState.Modified;


            return _context.SaveChanges();
        }
        public IQueryable FilterByKategori(int? kategoriId)
        {
            return _context.JenisDocuments.Include(x => x.KategoriDokumen).Where(x => x.KategoriDokumenId == kategoriId);
        }
    }
}