using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Transaction;
using My_OPR.Repositories.Data;

namespace My_OPR.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : BaseController<Content, ContentRepository, int>
    {
        private readonly ContentRepository _contentRepository;
        public ContentController(ContentRepository repository) : base(repository)
        {
            _contentRepository = repository;
        }

        [HttpGet]
        [Route("/api/[controller]/getall")]
        public ActionResult GetAll()
        {
            var result = _contentRepository.GetAll();
            return Ok(result);
        }

        [HttpDelete]
        [Route("/api/[controller]/delete")]
        public ActionResult SoftDelete(int id)
        {
            var result = _contentRepository.SoftDelete(id);
            return Ok(result);
        }
        [HttpPost]
        [Route("insert")]
        public IActionResult Insert(ViewModels.ContentVM content)
        {

            var result = _contentRepository.InsertContent(content);
            return Ok(new { id = result });
        }
        [HttpPut]
        [Route("insert")]
        public IActionResult Update(ViewModels.ContentVM content)
        {
            var result = _contentRepository.UpdateContent(content);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                data = result
            });
        }
        [HttpGet]
        [Route("GetContentByCategory/{id}")]
        public IActionResult GetByCategory(int id)
        {
            var contents = _contentRepository.GetAll().Where(c => c.CategoryId == id).ToList();

            return Ok(contents);
        }

    }



}
