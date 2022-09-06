using System.ComponentModel.DataAnnotations;

namespace MyEshop_2.Models
{
    public class Users
    {
        [Key]
    
        public  int  Id { get; set; }
        [Required(ErrorMessage = "لطفا ایمیل را درست وارد کنید")]
        [MaxLength(300)]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا پسورد را درست وارد کنید")]
        [MinLength(4)]
        [MaxLength(20)]

        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا فرمت تاریخ را درست وارد کنید")]

        public DateTime RegisterDate  { get; set; }

        public bool IsAdmin { get; set; }

       
        public List<Order> Orders { get; set; }
    }
}
