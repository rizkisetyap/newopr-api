using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Repositories.Interface;

namespace My_OPR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository _repository;

        public BaseController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Gets()
        {
            var result = _repository.Get();
            return Ok(result);
        }

        [HttpGet("{key}")]
        public virtual ActionResult<Entity> Get(Key key)
        {
            var result = _repository.Get(key);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<Entity> Update(Entity entity)
        {
            int result = _repository.Update(entity);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public virtual ActionResult<Entity> Insert(Entity entity)
        {
            int result = _repository.Insert(entity);

            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]

        public ActionResult<Entity> Delete([FromBody] Entity entity)
        {
            int result = _repository.Delete(entity);
            if (result <= 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}
