using WideBot.Models;

namespace WideBot.Repositories
{
    public interface ICartRepository
    {
        Task AddToCart(Cart cart);
        Task<Cart> getCart(int userid, int productid);

        Task<Cart> GetCartById(int id); 

        decimal GetCartPrice(int id);

        Task DeleteProduct(int userid , int productid);
    }
}
