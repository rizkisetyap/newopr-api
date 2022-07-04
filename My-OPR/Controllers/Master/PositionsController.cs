using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;

namespace My_OPR.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : BaseController<Position, PositionRepository, int>
    {
        private readonly PositionRepository _positionRepository;
        public PositionsController(PositionRepository repository) : base(repository)
        {
            _positionRepository = repository;
        }

        [HttpGet]
        [Route("/api/[controller]/getall")]
        public ActionResult GetAll()
        {
            return Ok(_positionRepository.GetAll());
        }

        [HttpDelete]
        [Route("/api/[controller]/delete")]
        public ActionResult SoftDelete(int id)
        {
            return Ok(_positionRepository.SoftDelete(id));
        }
    }
}
