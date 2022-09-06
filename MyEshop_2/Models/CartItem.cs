namespace MyEshop_2.Models
{
    public class CartItem
    {

        public int id { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal GettotalPrice()
        {
            return (Item.price * Quantity);
        }
    }
}
