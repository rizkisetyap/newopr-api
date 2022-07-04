using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;

namespace My_OPR.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeLocationController : BaseController<OfficeLocation, LocationRepository, int>
    {
        public OfficeLocationController(LocationRepository repository) : base(repository)
        {
        }
    }
}
