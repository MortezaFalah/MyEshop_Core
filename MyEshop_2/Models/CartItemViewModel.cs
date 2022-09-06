namespace MyEshop_2.Models
{
    public class CartItemViewModel
    {

        public CartItemViewModel()
        {
            CartItems = new List<CartItem>();
        }

        public decimal OrderTotal { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
