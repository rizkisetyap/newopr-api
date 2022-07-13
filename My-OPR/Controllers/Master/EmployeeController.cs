using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;
using My_OPR.ViewModels;
using My_OPR.Data;
namespace My_OPR.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly ApplicationDBContext _context;
        public EmployeeController(EmployeeRepository employeeRepository, ApplicationDBContext context)
        {
            _employeeRepository = employeeRepository;
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {

            return Ok(_employeeRepository.GetAll());
        }

        [HttpGet]
        [Route("By")]
        public IActionResult Get(string Id)
        {
            return Ok(_employeeRepository.Get(Id));
        }

        [HttpGet]
        [Route("/api/[controller]/Birthday")]
        public IActionResult Birthday()
        {
            var now = DateTime.Now; 
            var convert = now.Date;
            var bulan = now.Month;
            var tanggal = now.Day;
            var result = _context.Employees.Where(x=>x.DateOfBirth.Day == tanggal && x.DateOfBirth.Month == bulan);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateEmployee(RegisterVM model)
        {
            return Ok(_employeeRepository.Register(model));
        }
        [HttpPut]
        public ActionResult Update(Employee employee)
        {
            return Ok(_employeeRepository.Update(employee));
        }

        [HttpDelete]
        public ActionResult Delete(string npp)
        {
            return Ok(_employeeRepository.Delete(npp));
        }

        [HttpPut]
        [Route("/api/[controller]/resetpassword")]
        public ActionResult ResetPassword(string npp)
        {
            return Ok(_employeeRepository.ResetPassword(npp));
        }

    }
}
