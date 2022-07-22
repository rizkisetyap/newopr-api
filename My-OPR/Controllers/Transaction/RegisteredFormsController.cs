using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.DocumentISO;
using My_OPR.Repositories.Data.DokumenIso;
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
        #region cek no urut support
        [HttpGet]
        [Route("CekAntrian")]
        public IActionResult CheckAntrian(int? idSublayanan, int KategoriDokumenId, int Tahun, int bulan)
        {
            return Ok(_repository.cekAntrian(idSublayanan, KategoriDokumenId, bulan, Tahun));
        }
        #endregion
        #region cek antrian inti
        [HttpGet]
        [Route("CekAntrian/Inti")]
        public IActionResult CekAntrianInti(int GroupId)
        {
            return Ok(_repository.CekAntrianInti(GroupId));
        }
        #endregion

        #region RegisterForms
        [HttpPost]
        [Route("registerForm")]
        public async Task<IActionResult> Create(RegisteredForm model)
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
                case 409:
                    return StatusCode(StatusCodes.Status409Conflict);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
        [HttpGet]
        [Route("Filter")]
        public IActionResult Filter(int? GroupId)
        {
            return Ok(_repository.ListFormByUserSignin(GroupId));
        }
        [HttpGet]
        [Route("search")]
        public IActionResult Search(int ServiceId, int KategoriDocumentId, int? unitId)
        {
            return Ok(_repository.GetFormByServiceAndKategori(ServiceId, KategoriDocumentId, unitId));
        }
        //#region get byId
        //[HttpGet]
        //public IActionResult Get(int id)
        //{
        //    var result = _repository.GetById(id);
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(result);
        //}
        //#endregion
        #region Detail Register
        [HttpGet]
        [Route("DetailRegister")]
        public IActionResult GetDetailRegister(int Id)
        {
            try
            {
                return Ok(_repository.GetDetailRegisterById(Id));
            }
            catch (Exception)
            {

                throw new Exception("Bad Request");
            }
        }
        #endregion
        #region UpdateForms
        [HttpPut]
        [Route("DetailRegister")]
        public IActionResult UpdateForms([FromBody] UpdateFormVM model)
        {
            try
            {
                var result = _repository.UpdateForms(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        #endregion
    }

}