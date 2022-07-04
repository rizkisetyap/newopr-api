using My_OPR.Models.DocumentISO;
using My_OPR.Repositories.Data.DokumenIso;
using My_OPR.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace My_OPR.Controllers.Transaction
{
    [Route("Api/[controller]")]
    [ApiController]
    public class RegisteredFormsController : BaseController<RegisteredForm, RegisteredFormRepository, int>
    {
        private readonly RegisteredFormRepository _repository;
        public RegisteredFormsController(RegisteredFormRepository repository) : base(repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("/api/[controller]/getall")]
        public ActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpDelete]
        [Route("/api/[controller]/delete")]
        public ActionResult SoftDelete(int id)
        {
            int result = _repository.SoftDelete(id);
            return Ok(result);
        }
        [HttpGet]
        [Route("filter")]
        public IActionResult GetByServiceId([FromQuery] int? id)
        {
            var result = _repository.GetByServiceId(id);

            if (result == null) return BadRequest();
            return Ok(result);
        }
        [HttpGet]
        [Route("CheckNoReg")]
        public IActionResult CheckNoReg()
        {
            return Ok(_repository.checkNoUrut());
        }
    }

}