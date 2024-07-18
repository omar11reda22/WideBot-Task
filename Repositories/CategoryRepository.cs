using Microsoft.EntityFrameworkCore;
using WideBot.Models;
using WideBot.Mycontext;

namespace WideBot.Repositories
{
    public class CategoryRepository : IcategoryRepository
    {
        private readonly Applicationcontext context;

        public CategoryRepository(Applicationcontext context)
        {
            this.context = context;
        }

        public void Add(Category category)
        {
            context.categories.Add(category);   
            context.SaveChanges(); 
        }

        public List<Category> getall()
        {
            var categories = context.categories.AsNoTracking().ToList();
            return categories;
        }
    }
}
