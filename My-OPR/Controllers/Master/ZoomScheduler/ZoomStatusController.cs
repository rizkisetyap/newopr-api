
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.ZoomScheduler;
using My_OPR.Repositories.Data;

namespace My_OPR.Controllers.ZoomScheduler
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ZoomStatusController : BaseController<ZoomStatus, ZoomStatusRepository, int>
    {
        private readonly ZoomStatusRepository _repository;
        public ZoomStatusController(ZoomStatusRepository repository) : base(repository)
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
    }
}