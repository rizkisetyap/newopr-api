using My_OPR.Repositories.Data.DokumenIso;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.DocumentISO;
namespace My_OPR.Controllers.Master
{
    [ApiController]
    [Route("api/[controller]")]
    public class JenisDokumenController : BaseController<JenisDocument, JenisDokumenRepository, int>

    {

        public readonly JenisDokumenRepository _repository;
        public JenisDokumenController(JenisDokumenRepository repository) : base(repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }
        [HttpDelete]
        [Route("{key}")]
        public IActionResult SoftDelete(int Id)
        {
            var result = _repository.SoftDelete(Id);
            if (result != 1)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet]
        [Route("kategori")]
        public IActionResult GetByKat(int? Id)
        {
            return Ok(_repository.FilterByKategori(Id));
        }
    }
}