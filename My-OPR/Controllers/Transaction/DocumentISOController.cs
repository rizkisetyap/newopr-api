
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

        public DocumentISOController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> UploadIso(UploadIsoVM model)
        {

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
                .Include(x => x.RegisteredForm.Service.Group)
                .Where(x => x.Id == FileReg.Id)
                .Select(x => new
                {
                    Id = x.Id,
                    Group = x.RegisteredForm.Service.Group.GroupName,
                    Service = x.RegisteredForm.Service.ShortName,
                    Unit = x.RegisteredForm.Unit.Name,
                    FileName = x.FileRegisteredIso.FileName,
                    Rev = x.Revisi
                }).FirstOrDefault();
                if (model.FileIso != null)
                {

                    var path = Path.Combine("public", "Documet ISO", reg.Group, reg.Service);
                    path = reg.Unit != null ? Path.Combine(path, reg.Unit) : path;
                    var isDirExist = System.IO.Directory.Exists(path);
                    if (!isDirExist)
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    var base64 = model.FileIso.base64str;
                    base64 = base64.Substring(base64.IndexOf(',') + 1);
                    Byte[] bytes = Convert.FromBase64String(base64);
                    var fileName = FileReg.FileName;
                    filePath = UploadLib.UploadContent(bytes, reg.FileName, path, model.FileIso.extension);
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

    }
}