using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WideBot.Services;

namespace WideBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IcartService cartService;

        public CartController(IcartService cartService)
        {
            this.cartService = cartService;
        }

        // add product to cart 
        [HttpPost]
        public async Task<ActionResult> addtocart(int userid, int productid)
        {
            var cart =  cartService.AddToCart(userid, productid);
            return Ok(cart);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getcartdetails(int id)
        {
            var cartdetails = cartService.getcartbyid(id); 
            return Ok(cartdetails);
        }

        [HttpDelete]
        public async Task<ActionResult> Deleteproduct(int productid)
        {
            var cart =  cartService.Removeproduct(productid);

            return Ok(cart);
        }
    }
}
