using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.DocumentISO;
using My_OPR.Repositories.Data.DokumenIso;

namespace My_OPR.Controllers.Transaction
{
    [Route("Api/[controller]")]
    [ApiController]

    public class HistoryISOsController : BaseController<HistoryISO, HistoryIsoRepository, int>
    {
        private readonly HistoryIsoRepository _repository;
        public HistoryISOsController (HistoryIsoRepository repository) : base(repository)
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