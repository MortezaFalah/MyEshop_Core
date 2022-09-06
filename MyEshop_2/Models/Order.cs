using System.ComponentModel.DataAnnotations.Schema;

namespace MyEshop_2.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsFinaly { get; set; }

        [ForeignKey("UserId")] 
        public Users User { get; set; }

        [ForeignKey("OrderId")]
        public List<OrderDetails> OrderDetails { get; set; }


    }
}
