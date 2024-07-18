using WideBot.Models;

namespace WideBot.Repositories
{
    public interface IcategoryRepository
    {
        void Add(Category category);
        List<Category> getall();
    }
}
