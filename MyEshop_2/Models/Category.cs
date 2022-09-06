namespace MyEshop_2.Models
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public string Description { get; set; }



        public ICollection<CategoryToProduct> categoryToProducts { get; set; }


    }
}
