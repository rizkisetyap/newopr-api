
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_OPR.Data;
using My_OPR.Models.DocumentISO;

namespace My_OPR.Controllers.Master
{
    [ApiController]
    [Route("api/[controller]")]
    public class KategoriDocumentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public KategoriDocumentController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.KategoriDocuments.ToListAsync();

            return Ok(data);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] KategoriDocument model)
        {

            try
            {
                var newData = _context.Add<KategoriDocument>(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] KategoriDocument model)
        {
            try
            {
                _context.Entry<KategoriDocument>(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
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
                var exist = await _context.KategoriDocuments.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (exist == null)
                {
                    return NotFound();
                }
                _context.KategoriDocuments.Remove(exist);
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
                var data = await _context.KategoriDocuments.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }

    }
}