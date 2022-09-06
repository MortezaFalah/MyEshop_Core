namespace MyEshop_2.Models
{
    public class Product
    {
      
        public int id { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
