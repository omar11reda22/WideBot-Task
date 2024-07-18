using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WideBot.DTOs;
using WideBot.Services;

namespace WideBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Admin")] // only admin role can add a new category 
    public class CategoriesController : ControllerBase
    {
        private readonly IcategoryService categoryService;

        public CategoriesController(IcategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public ActionResult addcategory(CategoryDTO categoryDTO)
        {
            if(ModelState.IsValid)
            {
                categoryService.Add(categoryDTO);
                return Ok(categoryDTO);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult getallnamesofcategories()
        {
            var categories = categoryService.GetAll();
            return Ok(categories); 
        }
    }
}
