using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.DocumentISO;
using My_OPR.ViewModels;
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
            var result = _context.RegisteredForms.Include(x => x.Unit).Include(x => x.Service).Include(x => x.JenisDokumen)
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

        public int cekAntrian(int? subLayananId, int KategoriDokumenId, int bulan, int tahun)
        {
            int NoAntrian = 0;
            var datas = _context.RegisteredForms
            .Include(x => x.JenisDokumen)
            .Include(x => x.JenisDokumen!.KategoriDokumen)
            .Where(x => x.IsDelete == false && x.SubLayananId == subLayananId && x.JenisDokumen!.KategoriDokumen!.Id == KategoriDokumenId && x.Month == bulan && x.Year == tahun).ToList();

            if ((datas.Count == 0))
            {
                NoAntrian = 1;
            }
            else
                NoAntrian = datas.AsEnumerable().Last().NoUrut + 1;
            //NoAntrian = _context.Absensi.AsEnumerable().Last().NoAntrian + 1;
            return NoAntrian;
        }
        public async Task<int> RegisterFormIso(RegisteredForm model)
        {
            try
            {
                RegisteredForm Rg = new RegisteredForm();
                Rg.Name = model.Name;
                Rg.SubLayananId = model.SubLayananId;
                Rg.ServiceId = model.ServiceId;
                Rg.JenisDokumenId = model.JenisDokumenId;
                Rg.NoUrut = model.NoUrut;
                Rg.GroupId = model.GroupId;
                Rg.Year = model.Year;
                Rg.Month = model.Month;

                _context.Add<RegisteredForm>(Rg);
                _context.SaveChanges();
                var regId = Rg.Id;
                Rg = _context.RegisteredForms
                .Include(x => x.JenisDokumen)
                .Include(x => x.Group)
                .Include(x => x.Service)
                .Include(x => x.Unit)
                .Where(x => x.Id == regId).FirstOrDefault()!;
                var detailRegsiter = new DetailRegister();
                detailRegsiter.isActive = true;
                detailRegsiter.RegisteredFormId = Rg.Id;
                detailRegsiter.Revisi = 0;
                _context.Add<DetailRegister>(detailRegsiter);
                _context.SaveChanges();
                var oldReg = _context.RegisteredForms
                .Include(x => x.Service)
                .Include(x => x.Group)
                .Include(x => x.Unit)
                .FirstOrDefault(x => x.Id == regId)!;


                // var oldRg = _context.RegisteredForms.SingleOrDefault(x => x.Id == regId)!;
                var noForm = this.GeneratedNoForms(detailRegsiter.Id);
                #region komen
                // var generatedNoForms = "FRM.OPR";
                // generatedNoForms =
                // Rg.GroupId == null ?
                // generatedNoForms + "/" + Rg.NoUrut + "/" + (model.Month < 10 ? "0" + model.Month.ToString() : model.Month.ToString()) + "/" + (model.Year.ToString().Substring(2)) + "/REV." + (detailRegsiter.Revisi < 10 ? "0" + detailRegsiter.Revisi.ToString() : detailRegsiter.Revisi.ToString()) :
                // generatedNoForms + "." + oldReg.Group.GroupName + ((oldReg.ServiceId != null && oldReg.Service.ShortName.Trim() == "PGO") ? "." + oldReg.Service.ShortName : "") + (oldReg.SubLayananId != null ? "." + oldReg.Unit.Name : "") + "." + (oldReg.NoUrut < 10 ? "0" + oldReg.NoUrut.ToString() : oldReg.NoUrut) + "/" + (model.Month < 10 ? "0" + model.Month.ToString() : model.Month.ToString()) + "/" + (model.Year.ToString().Substring(2)) + "/REV." + (detailRegsiter.Revisi < 10 ? "0" + detailRegsiter.Revisi.ToString() : detailRegsiter.Revisi.ToString());
                // if (Rg.JenisDokumen.KategoriDokumenId == 1)
                // {
                //     generatedNoForms = generatedNoForms + "/" + (Rg.NoUrut < 10 ? "0" + Rg.NoUrut : Rg.NoUrut) + "/" + (model.Month < 10 ? "0" + model.Month : model.Month) + "/" + model.Year.ToString().Substring(2) + "/REV." + (detailRegsiter.Revisi < 10 ? "0" + detailRegsiter.Revisi : detailRegsiter.Revisi);
                // }
                // else
                // {
                //     generatedNoForms = generatedNoForms + "." + Rg.Group.GroupName + "." + (Rg.Service.ShortName == Rg.Group.GroupName ? "" : Rg.Service.ShortName + ".") +
                //     (Rg.Unit.ShortName == Rg.Service.ShortName ? "" : Rg.Unit.ShortName + ".")
                //     + (Rg.NoUrut < 10 ? "0" + Rg.NoUrut : Rg.NoUrut) + "/" + (
                //          (model.Month < 10 ? "0" + model.Month : model.Month)// bulan
                //          + "/" +
                //          (model.Year.ToString().Substring(2))
                //     ) + "/REV." + formatAngka(detailRegsiter.Revisi);
                // }
                #endregion

                oldReg.FormNumber = noForm;
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
        protected string formatAngka(int angka)
        {
            if (angka < 10)
            {
                return "0" + angka;
            }
            else
            {
                return angka.ToString();
            }
        }
        protected string formatBulanTahun(int? bulan, int? tahun)
        {
            var b = bulan.ToString();
            var t = tahun.ToString().Substring(2);
            if (bulan < 10)
            {
                b = "0" + bulan.ToString();
            }

            return "/" + bulan + "/" + tahun;
        }
        public IEnumerable<NoForm> GenerateListForms()
        {

            var a = _context.FileRegisteredIsos.Include(x => x.DetailRegister).Where(x => x.DetailRegisterId != null).Select(x => x.DetailRegisterId).ToList();

            var b = _context.DetailRegisters.Include(x => x.RegisteredForm).Include(x => x.RegisteredForm.Service)
            .Include(x => x.RegisteredForm.Service.Group).Include(x => x.RegisteredForm.Unit)
            .Where(x => !a.Contains(x.Id)).ToList().Select(x => new NoForm
            {
                RegId = x.Id,
                No = "FRM.OPR." + x.RegisteredForm?.Service?.Group?.GroupName + "." + x.RegisteredForm?.Service?.ShortName + (x.RegisteredForm?.SubLayananId != null ? "." + x.RegisteredForm.Unit.Name : "") + "." + x.RegisteredForm?.NoUrut + "/" + (
                    x.CreateDate.Month < 10 ? "0" + x.CreateDate.Month.ToString() : x.CreateDate.Month.ToString()
                ) + "/" + x.CreateDate.Year.ToString().Substring(2) + "/REV." + (x.Revisi < 10 ? "0" + x.Revisi : x.Revisi),
                NamaForm = x.RegisteredForm.Name!

            });
            ;

            return b;
        }
        public IQueryable ListFormByUserSignin(int? GroupId)
        {

            var conditions = _context.FileRegisteredIsos.Include(x => x.DetailRegister).Select(x => x.DetailRegisterId);
            var result = _context.DetailRegisters
            .Include(x => x.RegisteredForm)
            .Where(x => (x.RegisteredForm.GroupId == GroupId && !conditions.Contains(x.Id)) || (x.RegisteredForm.ServiceId == null && x.RegisteredForm.SubLayananId == null && x.RegisteredForm.GroupId == null));


            return result;
        }
        public IQueryable GetFormByServiceAndKategori(int ServiceId, int KategoriDokumenId, int? UnitId)
        {
            var filter = _context.DetailRegisters
            .Include(x => x.RegisteredForm)
            .Include(x => x.RegisteredForm!.JenisDokumen)
            .Where(x => x.isActive && x.RegisteredForm!.JenisDokumen!.KategoriDokumenId == KategoriDokumenId && x.RegisteredForm.ServiceId == ServiceId && x.RegisteredForm.SubLayananId == UnitId);
            // if (UnitId != null)
            // {
            //     filter = _context.DetailRegisters
            // .Include(x => x.RegisteredForm)
            // .Include(x => x.RegisteredForm!.JenisDokumen)
            // .Where(x => x.isActive && x.RegisteredForm!.JenisDokumen!.KategoriDokumenId == KategoriDokumenId && x.RegisteredForm.ServiceId == ServiceId && x.RegisteredForm.SubLayananId == UnitId);
            // }
            return filter.Select(x => new
            {
                Id = x.Id,
                NoForm = x.RegisteredForm.FormNumber,
                FormName = x.RegisteredForm.Name
            });
        }
        public string GeneratedNoForms(int DetailRegsiterId)
        {
            var DetailReg = (from DR in _context.DetailRegisters
                             join RF in _context.RegisteredForms on DR.RegisteredFormId equals RF.Id

                             join G in _context.Groups on RF.GroupId equals G.Id
                             join S in _context.Services on RF.ServiceId equals S.Id
                             join U in _context.Units on RF.SubLayananId equals U.Id
                             join JD in _context.JenisDocuments on RF.JenisDokumenId equals JD.Id
                             where DR.Id == DetailRegsiterId && DR.isActive == true
                             select new
                             {
                                 Kelompok = G.GroupName,
                                 Layanan = S.ShortName,
                                 Unit = U.ShortName,
                                 KategoriDokumenId = JD.KategoriDokumenId,
                                 Bulan = RF.Month < 10 ? "0" + RF.Month : RF.Month.ToString(),
                                 Tahun = RF.Year.ToString().Substring(2),
                                 Revisi = DR.Revisi < 10 ? "0" + DR.Revisi : DR.Revisi.ToString(),
                                 NoUrut = RF.NoUrut < 10 ? "0" + RF.NoUrut : RF.NoUrut.ToString()
                             }

            ).FirstOrDefault();

            var noForm = "FRM.OPR";
            if (DetailReg!.KategoriDokumenId == 1)
            {
                noForm = noForm + "/" + DetailReg.NoUrut + "/" + DetailReg.Bulan + "/" + DetailReg.Tahun + "/REV." + DetailReg.Revisi;
            }
            else
            {
                noForm = noForm + "." + DetailReg.Kelompok + "." + (DetailReg.Layanan == DetailReg.Kelompok ? "" : DetailReg.Layanan + ".") +
                    (DetailReg.Unit == DetailReg.Layanan ? "" : DetailReg.Unit + ".")
                    + DetailReg.NoUrut + "/" + DetailReg.Bulan
                         + "/" +
                         DetailReg.Tahun
                     + "/REV." + DetailReg.Revisi;
            }

            return noForm;
        }
        public RegisteredForm GetById(int id)
        {
            var result = _context.RegisteredForms
                .Include(x => x.Group)
                .Include(x => x.Service)
                .Include(x => x.Unit)
                .Where(x => x.IsDelete == false)
                .FirstOrDefault();
            return result;
        }
    }

}