namespace MyEshop_2.Models
{
    public class AddOrEditProductViewModel
    {


        public int Id { get; set; }

        public string  Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int QuantityinStock { get; set; }

        public IFormFile Picture { get; set; }

        public List<Category> Categories { get; set; }




    }
}
