using WideBot.DTOs;
using WideBot.Repositories;

namespace WideBot.Services
{
    public class ProductService : IProductService
    {
        private readonly IproductRepository repository;

        public ProductService(IproductRepository repository)
        {
            this.repository = repository;
        }

        public ProductDTO getbyid(int id)
        {
            var item = repository.getbyid(id);
            ProductDTO product = new()
            {
                Name = item.Name, 
                Price = item.Price, 
                CattegoryName = item.category.Name
            };
            return product; 
        }
    }
}
