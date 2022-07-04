using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;

namespace My_OPR.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListAppsController : BaseController<ListApp, ListAppRepository, int>
    {
        private readonly ListAppRepository _listappRepository;
        public ListAppsController(ListAppRepository listAppRepository) : base(listAppRepository)
        {
            _listappRepository = listAppRepository;
        }

        [HttpGet]
        [Route("/api/[controller]/getall")]
        public ActionResult GetAll()
        {
            return Ok(_listappRepository.GetAll());
        }

        [HttpDelete]
        [Route("/api/[controller]/delete")]
        public ActionResult SoftDelete(int id)
        {
            int result = _listappRepository.SoftDelete(id);
            return Ok(result);
        }
    }
}