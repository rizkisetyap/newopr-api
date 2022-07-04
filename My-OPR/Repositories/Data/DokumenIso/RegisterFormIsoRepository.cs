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
    }
}