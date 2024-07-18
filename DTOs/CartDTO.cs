namespace WideBot.DTOs
{
    public class CartDTO
    {
        public string UserName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
