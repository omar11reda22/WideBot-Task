namespace WideBot.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Ctg_ID { get; set; }
        public Category category { get; set; } = default!;

    }
}
