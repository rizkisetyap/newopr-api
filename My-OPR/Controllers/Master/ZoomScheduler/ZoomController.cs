

using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.ZoomScheduler;
using My_OPR.Repositories.Data.Zoom;

namespace My_OPR.Controllers.ZoomScheduler
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoomController : BaseController<ZoomModel, ZoomRepository, int>
    {
        private readonly ZoomRepository _repository;
        public ZoomController(ZoomRepository repository) : base(repository)
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