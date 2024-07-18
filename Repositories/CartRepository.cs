using Microsoft.EntityFrameworkCore;
using WideBot.Models;
using WideBot.Mycontext;

namespace WideBot.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly Applicationcontext context;

        public CartRepository(Applicationcontext context)
        {
            this.context = context;
        }

        public async Task AddToCart(Cart cart)
        {
           await context.carts.AddAsync(cart); 
           await context.SaveChangesAsync(); 
        }

        public async Task DeleteProduct(int userid ,int productid)
        {
            var cart = await context.carts.FirstOrDefaultAsync(s => s.UserID == userid && s.ProductID == productid);
            
            if (cart is not null)
            {
                context.carts.Remove(cart);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Cart> getCart(int userid, int productid)
        {
            var cart = await context.carts.FirstOrDefaultAsync(s => s.UserID == userid && s.ProductID == productid);
            return cart; 
        }

        public async Task<Cart> GetCartById(int id)
        {
            var cart =  context.carts.Include(p => p.product).FirstOrDefault(c => c.Cart_ID == id);
            return cart;

        }

        public decimal GetCartPrice(int id)
        {
            var cart = context.carts.Where(s => s.Cart_ID == id).Include(s => s.product);
            var totalprice = cart.Sum(s => s.Quantity * s.product.Price);
            return totalprice; 
        }
    }
}
