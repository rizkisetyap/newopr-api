using My_OPR.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Master;

namespace My_OPR.Controllers.Master
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : BaseController<Service, ServiceRepository, int>
    {
        public readonly ServiceRepository _repository;
        public ServicesController(ServiceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        [Route("/api/[controller]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var statuscode = await _repository.DeleteById(id);
            switch (statuscode)
            {
                case 200:
                    return Ok();
                case 404:
                    return NotFound();
                case 500:
                    return StatusCode(500);
                default:
                    return BadRequest();
            }
        }

        [HttpGet]
        [Route("/api/[controller]/getall")]
        public ActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }
        [HttpGet]
        [Route("Group")]
        public IActionResult GetByGroup(int? GroupId)
        {


            return Ok(_repository.GetByGroup(GroupId));
        }


    }
}