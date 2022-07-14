using My_OPR.Repositories.Data.DokumenIso;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.DocumentISO;
using My_OPR.ViewModels;
namespace My_OPR.Controllers.Transaction
{
    [ApiController]
    [Route("api/[controller]")]
    public class DokumenUtamaController : BaseController<ISOCore, DokumenUtamaRepository, int>
    {
        private readonly DokumenUtamaRepository _repository;
        public DokumenUtamaController(DokumenUtamaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult Upload(UploadDokumenUtamaVM model)
        {

            try
            {
                return Ok(_repository.UploadDokumenUtama(model));
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
    }
}