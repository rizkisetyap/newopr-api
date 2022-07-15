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

        [HttpGet]
        [Route("Group")]
        public IActionResult GetGroup()
        {
            return Ok(_repository.GetKelompok());
        }
        [HttpGet]
        [Route("Unit")]
        public IActionResult GetUnit(int serviceId)
        {
            return Ok(_repository.Unit(serviceId));
        }
        [HttpGet]
        [Route("Iso")]
        public IActionResult GetFiles(int unitId)
        {
            return Ok(_repository.GetFiles(unitId));
        }
        [HttpGet]
        [Route("count")]
        public IActionResult Count(int GroupId, int ServiceId, int unitId)
        {
            return Ok(_repository.Count(GroupId, ServiceId, unitId));
        }

    }
}