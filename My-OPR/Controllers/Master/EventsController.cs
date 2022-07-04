using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;

namespace My_OPR.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : BaseController<Event, EventRepository, int>
    {
        private readonly EventRepository _eventRepository;
        public EventsController(EventRepository eventRepository) : base(eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        [Route("/api/[controller]/getall")]
        public ActionResult GetAll()
        {
            return Ok(_eventRepository.GetAll());
        }

        [HttpDelete]
        [Route("/api/[controller]/delete")]
        public ActionResult SoftDelete(int id)
        {
            int result = _eventRepository.SoftDelete(id);
            return Ok(result);
        }
    }
}
