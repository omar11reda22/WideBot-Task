namespace WideBot.Models
{
    public class Category
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        = string.Empty;

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>(); 
    }
}
