using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.DocumentISO;
namespace My_OPR.Repositories.Data.DokumenIso
{
    public class RegisterFormIsoRepository : GenericRepository<ApplicationDBContext, RegisteredForm, int>
    {
        private readonly ApplicationDBContext _context;
        public RegisterFormIsoRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<RegisteredForm> GetAll()
        {
            var result = _context.RegisteredForms.Include(x => x.Unit).Include(x => x.Service).Include(x => x.SubLayananId).Include(x => x.KategoriDocument)
                .Where(x => x.IsDelete == false).ToList();

            return result;
        }

        public int SoftDelete(int id)
        {
            var datas = _context.RegisteredForms.Where(x => x.Id == id).FirstOrDefault();

            if (datas == null)
            {
                return 404;
            }
            else
            {
                datas.IsDelete = true;

                _context.Update(datas);
                try
                {
                    _context.SaveChanges();
                    return 200;
                }
                catch (System.Exception)
                {

                    return 500;
                }
            }
        }

        public int cekAntrian( int? subLayananId, int layananId)
        {
            int NoAntrian = 0;
            var datas = _context.RegisteredForms.Where(x=>x.IsDelete == false).ToList();
            if (subLayananId == null)
            {
                datas = _context.RegisteredForms.Where(x => x.IsDelete == false && x.ServiceId == layananId).ToList();
            }
            else
            {
                datas = _context.RegisteredForms.Where(x => x.IsDelete == false && x.SubLayananId == subLayananId && x.ServiceId == layananId).ToList();

            }
            //ToList();
            if ((datas.Count == 0))
            {
                NoAntrian = 1;
            }
            else
                NoAntrian = datas.AsEnumerable().Last().NoUrut + 1;
            //NoAntrian = _context.Absensi.AsEnumerable().Last().NoAntrian + 1;
            return NoAntrian;
        }
    }

}