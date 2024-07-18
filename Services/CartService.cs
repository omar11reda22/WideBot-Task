
using WideBot.DTOs;
using WideBot.Models;
using WideBot.Repositories;

namespace WideBot.Services
{
    public class CartService : IcartService
    {
        private readonly ICartRepository cartRepository;
        private readonly IUserService userService;
        public CartService(ICartRepository cartRepository, IUserService userService)
        {
            this.cartRepository = cartRepository;
            this.userService = userService;
        }
        // add product to cart 
        public async Task AddToCart(int productID, int Quantity)
        {
            var userid = await userService.GetUserIdAsync(); 
            if (userid == null)
            {
                throw new Exception("please login first");
            }

            if(!int.TryParse(userid , out var user_id))
            {
                var cart = cartRepository.getCart(user_id , productID);
                if(cart is null)
                {
                    // saving cart 
                    Cart ct = new() 
                    {
                    UserID = user_id, 
                    ProductID = productID, 
                    Quantity = Quantity
                    };
                   await cartRepository.AddToCart(ct); 

                }else
                {

                }
            }



        }

        // get cart details 
        public async Task<CartDTO> getcartbyid(int id)
        {
            var username = await userService.GetUserNameAsync();
             
            var cart = await cartRepository.GetCartById(id);

            var totalprice = cartRepository.GetCartPrice(id);

            CartDTO cartDTO = new() 
            {
            UserName = username,
            Quantity = cart.Quantity, 
            TotalPrice = totalprice
            };
            return cartDTO; 
        }

        public async Task Removeproduct(int productID)
        {
            var Userid = await userService.GetUserIdAsync();
            if (Userid == null)
                throw new Exception("this user is not found please login");

            if (!int.TryParse(Userid, out var user_id))
            {
              await cartRepository.DeleteProduct(user_id, productID);
            }

                
        }
    }
}
