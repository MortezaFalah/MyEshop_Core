namespace MyEshop_2.Models
{
    public class Cart
    {

        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public int OrderId { get; set; }

        public List<CartItem> CartItems { get; set; }

        public void AddItem(CartItem cartItem)
        {
            
            if (CartItems.Exists(i=>i.Item.id==cartItem.Item.id))
            {
                CartItems.Find(c => c.Item.id == cartItem.Item.id)
                    .Quantity += 1;
            }
            else
            {
                CartItems.Add(cartItem);
            }


        }

        public void RemoveItem(int itemid)
        {
            var cartItem = CartItems.SingleOrDefault(c => c.Item.id == itemid);

            if(cartItem?.Quantity<=1)
            {  
               CartItems.Remove(cartItem);
            }
            else if(cartItem != null&&cartItem.Quantity>1)
            {
                cartItem.Quantity -= 1;
            }
        }


    }
}
