using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_OPR.Models.Master;
using My_OPR.Repositories.Data;
using My_OPR.ViewModels;

namespace My_OPR.Controllers.Master
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController<Category, CategoryRepository, int>
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoriesController(CategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("/api/[controller]/getall")]
        public ActionResult GetAll()
        {
            return Ok(_categoryRepository.GetAll());
        }

        [HttpDelete]
        [Route("/api/[controller]/Delete")]
        public ActionResult SoftDelete(int id)
        {
            int result = _categoryRepository.SoftDelete(id);
            return Ok(result);
        }

        
    }
}
