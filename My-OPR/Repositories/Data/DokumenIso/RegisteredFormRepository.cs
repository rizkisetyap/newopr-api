using My_OPR.Data;
using My_OPR.Models.DocumentISO;
using Microsoft.EntityFrameworkCore;
using My_OPR.ViewModels;
namespace My_OPR.Repositories.Data.DokumenIso
{
    public class RegisteredFormRepository : GenericRepository<ApplicationDBContext, RegisteredForm, int>
    {
        private readonly ApplicationDBContext _context;
        public RegisteredFormRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public List<RegisteredForm> GetAll()
        {
            return _context.RegisteredForms.Where(x => x.IsDelete == false).ToList();
        }
        public int checkNoUrut()
        {
            return _context.RegisteredForms.Count() + 1;
        }
        public int SoftDelete(int id)
        {
            var data = _context.RegisteredForms.Find(id);
            if (data != null)
            {
                data.IsDelete = true;
                _context.Entry(data).State = EntityState.Modified;
            }
            var result = _context.SaveChanges();
            return result;
        }
        public List<RegisteredForm> GetByServiceId(int? id)
        {
            List<RegisteredForm> result;
            if (id == null)
            {
                result = _context.RegisteredForms.ToList();
                return result;
            }


            return _context.RegisteredForms.Where(x => x.ServiceId == id).ToList(); ;
        }

    }
}













