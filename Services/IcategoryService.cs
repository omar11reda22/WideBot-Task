using WideBot.DTOs;

namespace WideBot.Services
{
    public interface IcategoryService
    {
        void Add(CategoryDTO categoryDTO);
        List<CategoryDTO> GetAll(); 
    }
}
