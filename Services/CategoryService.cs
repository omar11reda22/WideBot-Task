using WideBot.DTOs;
using WideBot.Models;
using WideBot.Repositories;

namespace WideBot.Services
{
    public class CategoryService : IcategoryService
    {
      private readonly IcategoryRepository categoryRepository;

        public CategoryService(IcategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void Add(CategoryDTO categoryDTO)
        {
            Category category = new()
            {
                Name = categoryDTO.Name, 
            };
            categoryRepository.Add(category);

        }

        public List<CategoryDTO> GetAll()
        {
            var items = categoryRepository.getall().Select(s => new CategoryDTO {Name = s.Name }).ToList();
            return items;
           
        }
    }
}
