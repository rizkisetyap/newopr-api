using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;

namespace My_OPR.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : BaseController<Slider, SliderRepository, int>
    {
        private readonly SliderRepository _sliderRepository;
        public SlidersController(SliderRepository repository) : base(repository)
        {
            _sliderRepository = repository;
        }

        [HttpGet]
        [Route("/api/[controller]/getall")]
        public ActionResult GetAll()
        {
            return Ok(_sliderRepository.GetAll());
        }

        [HttpDelete]
        [Route("/api/[controller]/delete")]
        public ActionResult SoftDelete(int id)
        {
            return Ok(_sliderRepository.SoftDelete(id));
        }
        [HttpPost]
        [Route("insert")]
        public IActionResult InsertSlider(ViewModels.SliderVM model)
        {
            var result = _sliderRepository.InsertSlider(model);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                data = result
            });
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateSlider(ViewModels.SliderVM model)
        {
            var result = _sliderRepository.UploadSlider(model);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}
