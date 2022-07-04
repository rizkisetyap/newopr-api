
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;
using My_OPR.Models.ZoomScheduler;
using My_OPR.Repositories.Data.Zoom;

namespace My_OPR.Controllers.ZoomScheduler
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ZoomSchedulerController : BaseController<Scheduler, ZoomSchedulerRepository, int>
    {
        private readonly ZoomSchedulerRepository _repository;
        public ZoomSchedulerController(ZoomSchedulerRepository repository) : base(repository)
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