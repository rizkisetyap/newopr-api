using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Transaction;
using My_OPR.Repositories.Data.Transaction;
namespace My_OPR.Controllers.Transaction
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestLemburController : BaseController<Overtime, OvertimeRepository, Guid>
    {
        public readonly OvertimeRepository _repository;

        public RequestLemburController(OvertimeRepository repository) : base(repository)
        {
            _repository = repository;
        }

        #region getApproval
        [HttpGet]
        [Route("GetApproval")]
        public IActionResult GetApproval(int GroupId)
        {
            try
            {
                var data = _repository.GetApproval(GroupId);

                return Ok(data);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        #endregion
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Overtime model)
        {
            try
            {
                var result = _repository.RegisterOvertime(model);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("GetSurat")]
        public IActionResult GetSurat(string npp)
        {
            try
            {
                var data = _repository.GetDetail(npp);
                return Ok(data);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("ListSurat")]
        public IActionResult ListSurat(int GroupId)
        {
            try
            {
                var data = _repository.GetToApprove(GroupId);

                return Ok(data);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
