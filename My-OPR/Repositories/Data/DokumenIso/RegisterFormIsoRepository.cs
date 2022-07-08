using Microsoft.EntityFrameworkCore;
using My_OPR.ViewModels;
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
            var result = _context.RegisteredForms.Include(x => x.Unit).Include(x => x.Service).Include(x => x.KategoriDocument)
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

        public int cekAntrian(int? subLayananId, int layananId)
        {
            int NoAntrian = 0;
            var datas = _context.RegisteredForms.Where(x => x.IsDelete == false).ToList();
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
        public async Task<int> RegisterFormIso(RegisterFormVM model)
        {
            try
            {
                RegisteredForm Rg = new RegisteredForm();
                Rg.Name = model.RegisteredForm.Name;
                Rg.SubLayananId = model.RegisteredForm.SubLayananId;
                Rg.ServiceId = model.RegisteredForm.ServiceId;
                Rg.KategoriDocumentId = model.RegisteredForm.KategoriDocumentId;
                Rg.NoUrut = model.RegisteredForm.NoUrut;

                _context.Add<RegisteredForm>(Rg);
                _context.SaveChanges();
                var regId = Rg.Id;
                var detailRegsiter = new DetailRegister();
                detailRegsiter.isActive = true;
                detailRegsiter.RegisteredFormId = Rg.Id;
                detailRegsiter.Revisi = 0;
                _context.Add<DetailRegister>(detailRegsiter);
                _context.SaveChanges();
                var oldReg = _context.RegisteredForms
                .Include(x => x.Service)
                .Include(x => x.Service.Group)
                .Include(x => x.Unit)
                .FirstOrDefault(x => x.Id == regId)!;
                // var oldRg = _context.RegisteredForms.SingleOrDefault(x => x.Id == regId)!;
                oldReg.FormNumber = "FRM.OPR." + Rg.Service.Group.GroupName + "." + Rg.Service.ShortName + (Rg.SubLayananId != null ? "." + Rg.Unit.Name : "") + "." + Rg.NoUrut + "/" + (model.Month <= 10 ? "0" + model.Month.ToString() : model.Month) + "/" + model.Year.ToString().Substring(2) + "/REV." + (detailRegsiter.Revisi < 10 ? "0" + detailRegsiter.Revisi : detailRegsiter.Revisi);
                oldReg.UpdateDate = DateTime.Now;
                _context.Entry(oldReg).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return 200;

            }
            catch (System.Exception)
            {

                return 500;
            }
        }
        public async Task<IEnumerable<NoForm>> GenerateListForms()
        {
            var rg = _context.DetailRegisters.Include(x => x.RegisteredForm).Include(x => x.RegisteredForm.Service.Group).Include(x => x.RegisteredForm.Unit).ToList().Select(x => new NoForm
            {
                RegId = x.Id,
                No = "FRM.OPR." + x.RegisteredForm?.Service?.Group?.GroupName + "." + x.RegisteredForm?.Service?.ShortName + (x.RegisteredForm?.SubLayananId != null ? "." + x.RegisteredForm.Unit.Name : "") + "." + x.RegisteredForm?.NoUrut + "/" + (
                    x.CreateDate.Month < 10 ? "0" + x.CreateDate.Month.ToString() : x.CreateDate.Month.ToString()
                ) + "/" + x.CreateDate.Year.ToString().Substring(2) + "/REV." + (x.Revisi < 10 ? "0" + x.Revisi : x.Revisi),
                NamaForm = x.RegisteredForm.Name!

            });

            return rg;
        }
        // public async Task
    }

}