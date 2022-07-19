using Microsoft.AspNetCore.Mvc;
using My_OPR.Repositories.Data.DokumenIso;

namespace My_OPR.Controllers.Master
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminIsoController : ControllerBase
    {
        private readonly AdminIsoRepository _repository;
        public AdminIsoController(AdminIsoRepository repository)
        {
            _repository = repository;
        }

        #region Get Kelompok
        [HttpGet]
        [Route("Group")]
        public IActionResult GetGroup()
        {
            return Ok(_repository.GetKelompok());
        }
        #endregion
        #region get Unit
        [HttpGet]
        [Route("Unit")]
        public IActionResult GetUnit(int serviceId)
        {
            return Ok(_repository.Unit(serviceId));
        }
        #endregion
        #region get Iso
        [HttpGet]
        [Route("Iso")]
        public IActionResult GetFiles(int unitId)
        {
            return Ok(_repository.GetFiles(unitId));
        }
        #endregion
        #region Count, Not implemented
        [HttpGet]
        [Route("count")]
        public IActionResult Count(int GroupId, int ServiceId, int unitId)
        {
            return Ok(_repository.Count(GroupId, ServiceId, unitId));
        }
        #endregion
        #region
        [HttpGet]
        [Route("history")]
        public IActionResult History(int fileId)
        {
            var result = _repository.History(fileId);
            return Ok(result);
        }
        #endregion
        #region ISR
        [HttpGet]
        [Route("ISR")]
        public IActionResult GetISR()
        {
            return Ok(_repository.FilesISR());
        }
        #endregion
    }
}