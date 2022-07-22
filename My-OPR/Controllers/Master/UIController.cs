using Microsoft.AspNetCore.Mvc;
using My_OPR.Data;
using My_OPR.Models.Transaction;
namespace My_OPR.Controllers.Master
{
    [ApiController]
    [Route("api/[controller]")]
    public class UIController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UIController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("sliderKonten")]
        public IActionResult SliderKonten()
        {
            List<Content> Kontens = new List<Content>();
            var kategori = _context.Categories.Select(x => new
            {
                Id = x.Id,
                Name = x.Nama
            }).ToList();


            foreach (var item in kategori)
            {
                var konten = _context.Contents.OrderByDescending(x => x.CreateDate).Where(x => x.CategoryId == item.Id).FirstOrDefault();
                if (konten != null)
                {
                    Kontens.Add(konten);

                }
            }

            return Ok(Kontens);
        }
    }
}
