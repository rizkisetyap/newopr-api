using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;

namespace My_OPR.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : BaseController<Group, GroupRepository, int>
    {
        private readonly GroupRepository _groupRepository;
        public GroupsController(GroupRepository repository) : base(repository)
        {
            _groupRepository = repository;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult GetAll()
        {
            return Ok(_groupRepository.GetAll());
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult SoftDelete(int id)
        {
            return Ok(_groupRepository.SoftDelete(id));
        }



    }
}
