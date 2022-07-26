using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.DocumentISO;
using My_OPR.Repositories.Data.DokumenIso;
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
        #region Upload 
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

                return StatusCode(StatusCodes.Status409Conflict);
            }
        }
        #endregion
        #region GetByGroup
        [HttpGet]
        [Route("Group")]
        public IActionResult GetByGroup(int GroupId)
        {
            try
            {
                var result = _repository.GetByGroup(GroupId);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion
        #region Update
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateDokumen([FromBody] UpdateIsoCoreVM model, int Id)
        {
            try
            {
                var result = _repository.Update(model, Id);

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}