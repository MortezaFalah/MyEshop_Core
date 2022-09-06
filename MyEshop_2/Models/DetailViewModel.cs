namespace MyEshop_2.Models
{
    public class DetailViewModel
    {

        public Product Product { get; set; }

        public ICollection<Category> categories { get; set; }
    }
}
