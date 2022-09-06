namespace MyEshop_2.Models
{
    public class Item
    {

        public int id { get; set; }

        public decimal price { get; set; }

        public int QuantityinStock { get; set; }

        public Product Product { get; set; }
    }
}
