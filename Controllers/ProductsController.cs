using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WideBot.Services;

namespace WideBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Admin")] // admin only can add a new product 
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public ActionResult getbyid(int id)
        {
            var product = _productService.getbyid(id);
            if (product is null)
                return BadRequest("No product"); 
            return Ok(product);
        }
    }
}
