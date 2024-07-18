using WideBot.DTOs;

namespace WideBot.Services
{
    public interface IProductService
    {
        ProductDTO getbyid(int id);
    }
}
