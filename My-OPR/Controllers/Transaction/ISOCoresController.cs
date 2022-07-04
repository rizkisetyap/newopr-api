using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.DocumentISO;
using My_OPR.Repositories.Data.DokumenIso;
using My_OPR.ViewModels;

namespace My_OPR.Controllers.Transaction
{
    [Route("api/[controller]")]
    [ApiController]
    public class ISOCoresController : BaseController<ISOCore, ISOCoreRepository, int>
    {
        private readonly ISOCoreRepository _isocoreRepository;
        public ISOCoresController(ISOCoreRepository isocoreRepository) : base(isocoreRepository)
        {
            _isocoreRepository = isocoreRepository;
        }

        [HttpGet]
        [Route("/api/[controller]/getall")]
        public ActionResult GetAll()
        {
            return Ok(_isocoreRepository.GetAll());
        }

        [HttpDelete]
        [Route("/api/[controller]/delete")]
        public ActionResult SoftDelete(int id)
        {
            int result = _isocoreRepository.SoftDelete(id);
            return Ok(result);
        }
        [HttpPost]
        [Route("UploadIso")]
        public IActionResult UploadIsoCore([FromBody] IsoCoreVM model)
        {
            var result = _isocoreRepository.InsertDocument(model);
            switch (result)
            {
                case 400:
                    return BadRequest();
                case 500:
                    return StatusCode(StatusCodes.Status500InternalServerError);
                case 404:
                    return StatusCode(StatusCodes.Status404NotFound);
                default:
                    return Ok();
            }
        }
    }
}


















