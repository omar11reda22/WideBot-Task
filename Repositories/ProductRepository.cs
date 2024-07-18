using Microsoft.EntityFrameworkCore;
using WideBot.Models;
using WideBot.Mycontext;

namespace WideBot.Repositories
{
    public class ProductRepository : IproductRepository
    {
        private readonly Applicationcontext context;

        public ProductRepository(Applicationcontext context)
        {
            this.context = context;
        }

        public Product getbyid(int id)
        {
            var product = context.products.Include(c => c.category).FirstOrDefault(p => p.ID == id);
            return product;
        }
    }
}
