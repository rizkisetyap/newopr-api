using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
namespace My_OPR.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public DashboardController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("info")]
        public IActionResult DashbboardInfo()
        {
            var user = _context.Employees.Where(u => u.IsDelete == false).Count();
            var events = _context.Events.Where(e => e.IsDelete == false).Count();
            var category = _context.Categories.Where(c => c.IsDelete == false).Count();
            var contents = _context.Contents.Where(c => c.IsDelete == false).Count();
            var sliders = _context.Sliders.Where(s => s.IsDelete == false).Count();
            //var event = 1;k
            return Ok(new
            {
                user,
                events,
                category,
                contents,
                sliders
            });
        }
    }
}
