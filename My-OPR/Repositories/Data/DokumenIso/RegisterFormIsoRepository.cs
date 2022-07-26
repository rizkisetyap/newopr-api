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

        public IQueryable GetAll()
        {
            var result = _context.DetailRegisters
                .Include(x => x.RegisteredForm)
                .Include(x => x.RegisteredForm.Group)
                .Include(x => x.RegisteredForm.Service)
                .Include(x => x.RegisteredForm.Unit)
                .Include(x => x.RegisteredForm.JenisDokumen)
                .Include(x => x.RegisteredForm.JenisDokumen.KategoriDokumen)
                .OrderBy(x => x.RegisteredForm.Group.GroupName)
                .ThenBy(x => x.RegisteredForm.Unit.ShortName)
                .ThenBy(x => x.RegisteredForm.NoUrut)
                .ThenBy(x => x.RegisteredForm.JenisDokumen.KategoriDokumen.Name)
                .ThenBy(x => x.RegisteredForm.Service.ShortName)
                .ThenBy(x => x.RegisteredForm.Name)
                .Where(x => x.isActive == true && x.IsDelete == false).Select(x => new
                {
                    Id = x.Id,
                    formNumber = x.RegisteredForm.FormNumber,
                    formName = x.RegisteredForm.Name,
                    kelompok = x.RegisteredForm.Group.GroupName,
                    KategoriDokumen = x.RegisteredForm.JenisDokumen.KategoriDokumen.Name,
                    layanan = new
                    {
                        shortName = x.RegisteredForm.Service.ShortName,
                        name = x.RegisteredForm.Service.Name
                    },
                    unit = new
                    {
                        name = x.RegisteredForm.Unit.Name,
                        shortName = x.RegisteredForm.Unit.ShortName
                    },
                    fileIso = _context.FileRegisteredIsos.Any(f => f.DetailRegisterId == x.Id),
                    lastUpdate = x.RegisteredForm.UpdateDate != null ? x.RegisteredForm.UpdateDate : x.RegisteredForm.CreateDate,
                    createDate = x.RegisteredForm.CreateDate
                });

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

        public int? cekAntrian(int? subLayananId, int KategoriDokumenId, int bulan, int tahun)
        {
            if (KategoriDokumenId != 3)
            {
                return null;
            }
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
        public int? CekAntrianInti(int GroupId)
        {
            var antrian = 0;
            var data = _context.RegisteredForms.Include(x => x.JenisDokumen).Where(x => x.IsDelete == false && x.GroupId == GroupId && x.JenisDokumen.KategoriDokumenId == 1).ToList();
            if (data.Count == 0)
            {
                antrian = 1;
            }
            else
            {
                antrian = data.AsEnumerable().Last().NoUrut + 1;
            }
            return antrian;
        }
        public async Task<int> RegisterFormIso(RegisteredForm model)
        {

            try
            {
                var kategoriDocId = _context.JenisDocuments.Where(x => x.Id == model.JenisDokumenId).Select(x => x.KategoriDokumenId).FirstOrDefault();
                if (kategoriDocId != 3)
                {
                    var formExist = _context.DetailRegisters
                        .Include(x => x.RegisteredForm)
                        .Include(x => x.RegisteredForm.Group)
                        .Include(x => x.RegisteredForm.Service)
                        .Include(x => x.RegisteredForm.Unit)
                        .Any(
                        x => x.isActive == true &&
                        x.IsDelete == false &&
                        x.RegisteredForm.IsDelete == false &&
                        x.RegisteredForm.JenisDokumenId == model.JenisDokumenId &&
                        x.RegisteredForm.GroupId == model.GroupId
                        );
                    if (formExist)
                    {
                        return 409;
                    }
                }
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

            //var conditions = _context.FileRegisteredIsos.Include(x => x.DetailRegister).Select(x => x.DetailRegisterId);
            var result = _context.DetailRegisters
            .Include(x => x.RegisteredForm)
            .Where(x => x.RegisteredForm.GroupId == GroupId && x.IsDelete == false && x.isActive == true)
            .OrderByDescending(x => x.UpdateDate).ThenByDescending(x => x.CreateDate)
            .Select(x => new
            {
                Id = x.Id,
                FormId = x.RegisteredFormId,
                FormName = x.RegisteredForm.Name,
                FormNumber = x.RegisteredForm.FormNumber,
                FileIso = _context.FileRegisteredIsos.Any(f => f.DetailRegisterId == x.Id),
                UpdateDate = x.CreateDate
            });

            return result;
        }
        public IQueryable GetFormByServiceAndKategori(int ServiceId, int KategoriDokumenId, int? UnitId)
        {
            int? Kategori = _context.JenisDocuments.Where(x => x.Id == KategoriDokumenId).Select(x => x.KategoriDokumenId).FirstOrDefault();
            var sId = _context.Units.Where(x => x.Id == UnitId).Select(x => x.ServiceId).FirstOrDefault();
            var GroupId = _context.Services.Where(x => x.Id == sId).Select(x => x.GroupId).FirstOrDefault();


            var isFileExist = _context.FileRegisteredIsos.Include(x => x.DetailRegister)
                .Include(x => x.DetailRegister.RegisteredForm).Select(x => x.DetailRegister.RegisteredFormId).ToList();


            var filter = _context.DetailRegisters
            .Include(x => x.RegisteredForm)
            .Include(x => x.RegisteredForm!.JenisDokumen)
            .Where(x => x.isActive == true && x.RegisteredForm.IsDelete == false && x.IsDelete == false && x.RegisteredForm!.JenisDokumen!.KategoriDokumenId == Kategori && !isFileExist.Contains(x.RegisteredFormId));

            if (Kategori == 3)
            {
                var result = filter.Where(x => x.RegisteredForm.ServiceId == sId && x.RegisteredForm.SubLayananId == UnitId).Select(x => new
                {
                    Id = x.Id,
                    NoForm = x.RegisteredForm.FormNumber,
                    FormName = x.RegisteredForm.Name
                });
                return result;
            }

            var final = filter
                .Where(x => x.RegisteredForm.JenisDokumenId == KategoriDokumenId && x.RegisteredForm.GroupId == GroupId)
                .OrderByDescending(x => x.UpdateDate)
                .ThenByDescending(x => x.CreateDate);

            return final.Select(x => new
            {
                Id = x.Id,
                NoForm = x.RegisteredForm.FormNumber,
                FormName = x.RegisteredForm.Name
            });
        }
        public string GeneratedNoForms(int DetailRegsiterId)
        {
            //var DetailReg = (from DR in _context.DetailRegisters
            //                 join RF in _context.RegisteredForms on DR.RegisteredFormId equals RF.Id into RegisterForms
            //                 from RegisterForm in RegisterForms.DefaultIfEmpty()

            //                 join G in _context.Groups on RegisterForm.GroupId equals G.Id into Groups
            //                 from Group in Groups.DefaultIfEmpty()
            //                 join S in _context.Services on RegisterForm.ServiceId equals S.Id
            //                 join U in _context.Units on RegisterForm.SubLayananId equals U.Id
            //                 join JD in _context.JenisDocuments on RegisterForm.JenisDokumenId equals JD.Id
            //                 where DR.Id == DetailRegsiterId && DR.isActive == true
            //                 select new
            //                 {
            //                     Kelompok = Group.GroupName,
            //                     Layanan = S.ShortName,
            //                     Unit = U.ShortName,
            //                     KategoriDokumenId = JD.KategoriDokumenId,
            //                     Bulan = RegisterForm.Month < 10 ? "0" + RegisterForm.Month : RegisterForm.Month.ToString(),
            //                     Tahun = RegisterForm.Year.ToString().Substring(2),
            //                     Revisi = DR.Revisi < 10 ? "0" + DR.Revisi : DR.Revisi.ToString(),
            //                     NoUrut = RegisterForm.NoUrut < 10 ? "0" + RegisterForm.NoUrut : RegisterForm.NoUrut.ToString()
            //                 }

            //).FirstOrDefault();
            var DetailReg = _context.DetailRegisters
                .Include(x => x.RegisteredForm)
                .Include(x => x.RegisteredForm.Group)
                .Include(x => x.RegisteredForm.Service)
                .Include(x => x.RegisteredForm.Unit)
                .Include(x => x.RegisteredForm.JenisDokumen)
                .Where(x => x.Id == DetailRegsiterId && x.IsDelete == false && x.isActive == true && x.RegisteredForm.IsDelete == false)
                .Select(x => new
                {
                    Kelompok = x.RegisteredForm.Group.GroupName,
                    Layanan = x.RegisteredForm.Service.ShortName ?? null,
                    Unit = x.RegisteredForm.Unit.ShortName ?? null,
                    KategoriDokumenId = x.RegisteredForm.JenisDokumen.KategoriDokumenId,
                    Bulan = x.RegisteredForm.Month < 10 ? "0" + x.RegisteredForm.Month : x.RegisteredForm.Month.ToString() ?? null,
                    Tahun = x.RegisteredForm.Year.ToString().Substring(2) ?? null,
                    Revisi = x.Revisi < 10 ? "0" + x.Revisi : x.Revisi.ToString() ?? null,
                    NoUrut = x.RegisteredForm.NoUrut < 10 ? "0" + x.RegisteredForm.NoUrut : x.RegisteredForm.NoUrut.ToString()
                }).FirstOrDefault();

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

        #region Get By Id
        public DetailRegister GetDetailRegisterById(int id)
        {
            var result = _context.DetailRegisters
                .Include(x => x.RegisteredForm)
                .Include(x => x.RegisteredForm.Group)
                .Include(x => x.RegisteredForm.Service)
                .Include(x => x.RegisteredForm.Unit)
                .Where(x => x.IsDelete == false && x.isActive == true && x.Id == id).FirstOrDefault();


            return result;
        }
        #endregion
        #region UpdateForm
        public int? UpdateForms(UpdateFormVM model)
        {
            try
            {
                var DetailReg = _context.DetailRegisters.Include(x => x.RegisteredForm)
                .Where(x => x.Id == model.Id && x.isActive == true && x.IsDelete == false).FirstOrDefault();
                var forms = _context.RegisteredForms
                    .Where(x => x.Id == DetailReg.RegisteredFormId && x.IsDelete == false).FirstOrDefault();

                forms.NoUrut = model.NoUrut;
                forms.Name = model.Name;
                forms.Month = model.Month;
                forms.Year = model.Year;
                DetailReg.Revisi = model.Revisi;

                _context.Entry(DetailReg).State = EntityState.Modified;
                _context.Entry(forms).State = EntityState.Modified;
                _context.SaveChanges();

                var newNoForm = this.GeneratedNoForms(model.Id);
                var oldForm = _context.RegisteredForms.Where(x => x.Id == DetailReg.RegisteredFormId && x.IsDelete == false).FirstOrDefault();
                if (oldForm != null)
                {
                    oldForm.FormNumber = newNoForm;
                }
                _context.Entry(oldForm).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        #endregion
    }

}