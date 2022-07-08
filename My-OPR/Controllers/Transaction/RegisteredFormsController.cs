using My_OPR.Models.DocumentISO;
using My_OPR.Repositories.Data.DokumenIso;
using My_OPR.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using My_OPR.ViewModels;

namespace My_OPR.Controllers.Transaction
{
    [Route("Api/[controller]")]
    [ApiController]
    public class RegisteredFormsController : BaseController<RegisteredForm, RegisterFormIsoRepository, int>
    {
        private readonly RegisterFormIsoRepository _repository;
        public RegisteredFormsController(RegisterFormIsoRepository repository) : base(repository)
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
        [Route("CekAntrian")]
        public IActionResult CheckAntrian(int? idSublayanan, int idLayanan)
        {
            return Ok(_repository.cekAntrian(idSublayanan, idLayanan));
        }
        [HttpPost]
        [Route("registerForm")]
        public async Task<IActionResult> Create(RegisterFormVM model)
        {
            var status = await _repository.RegisterFormIso(model);
            switch (status)
            {
                case 200:
                    return Ok();
                case 400:
                    return BadRequest();
                case 404:
                    return NotFound();
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("ListForms")]
        public async Task<IActionResult> GetList()
        {
            // var ListForms = null;
            return Ok(await _repository.GenerateListForms());
        }



    }

}