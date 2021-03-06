
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.Master;

namespace My_OPR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        public UnitController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? serviceId)
        {


            var data = await _context.Units.Where(x => x.IsDelete == false && x.ServiceId == serviceId).OrderBy(x => x.ShortName).ThenBy(x => x.Name).ToListAsync();

            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubLayanan model)
        {
            try
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SubLayanan model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _context.Units.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (data == null) return NotFound();
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _context.Units.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (data == null) return NotFound();
                _context.Remove(data);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("layanan")]
        public IActionResult GetByLayanan(int? id)
        {
            var result = _context.Units.Where(x => x.ServiceId == id).OrderBy(x => x.ShortName).ThenBy(x => x.Name);

            return Ok(result);
        }
        [HttpGet]
        [Route("Search")]
        public IActionResult Search(int? GroupId)
        {
            var Search = (from U in _context.Units
                          join S in _context.Services on U.ServiceId equals S.Id
                          join G in _context.Groups on S.GroupId equals G.Id
                          where G.Id == GroupId
                          orderby U.ShortName ascending
                          orderby U.Name ascending
                          select U
                ).ToList();

            return Ok(Search);
        }

    }
}