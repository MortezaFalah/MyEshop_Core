using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEshop_2.Models
{
    public class OrderDetails
    {
        [Key]
        public int DetailId { get; set; }

        public decimal Price   { get; set; }

        public int Count { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }


        public Order Order { get; set; }
       
        public Product product { get; set; }


    }
}
