using WideBot.DTOs;

namespace WideBot.Services
{
    public interface IcartService
    {
        Task AddToCart(int productID , int Quantity);

        Task<CartDTO> getcartbyid(int id);
        Task Removeproduct(int productID); 
    }
}
