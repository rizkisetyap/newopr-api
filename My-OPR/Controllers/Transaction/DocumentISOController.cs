// #nullable disable
using My_OPR.Repositories.Data.DokumenIso;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Data;
using My_OPR.ViewModels;
using My_OPR.Models.DocumentISO;
using My_OPR.Lib;
using Microsoft.EntityFrameworkCore;
namespace My_OPR.Controllers.Transaction
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentISOController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly DocumentISORepository _repository;

        public DocumentISOController(ApplicationDBContext context, DocumentISORepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult UploadIso(UploadIsoVM model)
        {
            var user = _context.Employees
            .Include(x => x.Service)
            .Include(x => x.Service!.Group)
            .Where(x => x.NPP == model.npp)
            .Select(x => new
            {
                Group = x.Service!.Group!.GroupName,
                Service = x.Service.ShortName,
                ServiceId = x.ServiceId!
            }).FirstOrDefault();
            FileRegisteredIso temp = model.FileRegisteredIso;
            temp!.ServiceId = user!.ServiceId;

            try
            {
                _context.Add(model.FileRegisteredIso);
                _context.SaveChanges();
                var FileReg = model.FileRegisteredIso;
                string filePath = "";
                var reg = _context.DetailRegisters
                .Include(x => x.RegisteredForm)
                .Include(x => x.RegisteredForm.KategoriDocument)
                .Include(x => x.RegisteredForm.Unit)
                .Include(x => x.RegisteredForm.Service)
                .Include(x => x.RegisteredForm.Group)
                .Where(x => x.Id == FileReg.DetailRegisterId)
                .Select(x => new
                {
                    Id = x.Id,
                    Group = x.RegisteredForm.Group.GroupName,
                    Service = x.RegisteredForm.Service.ShortName,
                    Unit = x.RegisteredForm.Unit.Name,
                    FileName = x.FileRegisteredIso.FileName,
                    Rev = x.Revisi
                }).FirstOrDefault();
                if (model.FileIso != null)
                {


                    var path = Path.Combine("public", "Document ISO");
                    if (reg.Group == null)
                    {
                        path = Path.Combine(path, user.Group, "Document Inti");
                    }
                    else
                    {
                        path = Path.Combine(path, user.Group);
                    }
                    path = reg.Service != null ? Path.Combine(path, reg.Service) : path;
                    path = reg.Unit != null ? Path.Combine(path, reg.Unit) : path;
                    var isDirExist = System.IO.Directory.Exists(path);
                    if (!isDirExist)
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    var base64 = model.FileIso.base64str;
                    base64 = base64.Substring(base64.IndexOf(',') + 1);
                    Byte[] bytes = Convert.FromBase64String(base64);
                    var fileName = FileReg.FileName + "_REV." + (reg.Rev < 10 ? "0" + reg.Rev : reg.Rev);
                    filePath = UploadLib.UploadContent(bytes, fileName, path, model.FileIso.extension);
                    FileReg.FilePath = filePath;
                    _context.SaveChanges();
                    return Ok(FileReg);
                }
                return BadRequest();
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        // [Route("Test")]
        public IActionResult Tes()
        {
            var result = _context.FileRegisteredIsos
            .Include(x => x.DetailRegister)
            .Include(x => x.DetailRegister.RegisteredForm)
            .Include(x => x.DetailRegister.RegisteredForm.KategoriDocument)
            .Include(x => x.DetailRegister.RegisteredForm.Service)
            .Include(x => x.DetailRegister.RegisteredForm.Service.Group)
            .Include(x => x.DetailRegister.RegisteredForm.Unit)
            .ToList();
            return Ok(result);
        }

        [HttpPut]
        [Route("/api/[controller]/edit/{id}")]
        public IActionResult Edit(int id, [FromBody] UpdateIsoVM model)
        {
            try
            {
                var filelama = _context.FileRegisteredIsos.Include(x => x.DetailRegister).Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();

                filelama.IsDelete = true;
                filelama.DeleteDate = DateTime.Now;
                _context.Update(filelama);
                _context.SaveChanges();

                var idDetLama = filelama.DetailRegisterId;

                var detLama = _context.DetailRegisters.Where(x => x.Id == idDetLama && x.isActive == true)
                .Include(x => x.RegisteredForm)
                .Include(x => x.RegisteredForm.Service)
                .Include(x => x.RegisteredForm.Service.Group)
                .Include(x => x.RegisteredForm.Unit)
                .FirstOrDefault();

                detLama.isActive = false;
                detLama.UpdateDate = DateTime.Now;
                _context.Update(detLama);
                _context.SaveChanges();

                DetailRegister detBaru = new DetailRegister();

                detBaru.RegisteredFormId = detLama.RegisteredFormId;
                detBaru.Revisi = detLama.Revisi + 1;
                detBaru.isActive = true;
                detBaru.CreateDate = DateTime.Now;
                _context.Add(detBaru);
                _context.SaveChanges();

                FileRegisteredIso fileBaru = new FileRegisteredIso();
                // Binding *
                var Group = detLama.RegisteredForm.Service.Group.GroupName;
                var Layanan = detLama.RegisteredForm.Service.ShortName;
                var Unit = detLama.RegisteredForm.Unit.Name;

                fileBaru.FileName = filelama.FileName;
                fileBaru.FilePath = filelama.FilePath;
                if (model.fileName != null)
                {
                    fileBaru.FileName = model.fileName;
                }
                if (model.document != null)
                {
                    var path = Path.Combine("public", "Document ISO", Group, Layanan);
                    path = Unit != null ? path + Path.Combine(path, Unit) : path;
                    var isDirExist = System.IO.Directory.Exists(path);
                    if (!isDirExist)
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    var base64str = model.document.base64str;
                    base64str = base64str.Substring(base64str.IndexOf(",") + 1);
                    Byte[] bytes = Convert.FromBase64String(base64str);
                    var rev = detBaru.Revisi < 10 ? "0" + detBaru.Revisi : detBaru.Revisi.ToString();
                    var imgPath = UploadLib.UploadContent(bytes, model.fileName + "_REV." + rev, path, model.document.extension);
                    fileBaru.FilePath = imgPath;

                }
                fileBaru.DetailRegisterId = detBaru.Id;
                fileBaru.IsDelete = false;
                fileBaru.CreateDate = DateTime.Now;
                _context.Add(fileBaru);
                _context.SaveChanges();

                return Ok();
            }
            catch (SystemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        #region documentIsoFilter
        [HttpGet]
        [Route("filter")]
        public IActionResult Filter(int? groupId, int? serviceId, string? npp)
        {
            if (npp != null)
            {
                return Ok(_repository.GetByNpp(npp));
            }
            var result = _context.FileRegisteredIsos
            .Include(x => x.DetailRegister)
            .Include(x => x.DetailRegister.RegisteredForm)
            .Include(x => x.DetailRegister.RegisteredForm.KategoriDocument)
            .Select(x => new
            {
                Id = x.Id,
                RegisterFormId = x.DetailRegister.RegisteredFormId,
                FormName = x.DetailRegister.RegisteredForm.Name,
                FormNumber = x.DetailRegister.RegisteredForm.FormNumber,
                JenisDokumen = x.DetailRegister.RegisteredForm.KategoriDocument.Name,
                isActive = x.DetailRegister.isActive,
                ServiceId = x.DetailRegister.RegisteredForm.ServiceId,
                GroupId = x.DetailRegister.RegisteredForm.Service.GroupId,
                FilePath = x.FilePath
            }).Where(x => (x.GroupId == groupId || x.ServiceId == serviceId) && x.isActive == true);

            return Ok(result);
        }
        #endregion
    }
}