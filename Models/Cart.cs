namespace WideBot.Models
{
    public class Cart
    {
        public int Cart_ID { get; set; }
        public int UserID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public Product product { get; set; } = default!;
    }
}
