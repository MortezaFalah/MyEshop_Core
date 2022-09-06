using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyEshop_2.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage = "لطفا فرمت {0} را درست وارد کنید")]
        [Display(Name = "ایمیل ")]
        [Remote("CheckEmail","Account")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "حداقل 8 کارکتر باید وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کارکتر می توانیدوارد کنید")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(8, ErrorMessage = "حداقل 8 کارکتر باید وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کارکتر می توانیدوارد کنید")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "تکرار کلمه عبور با قبلی همخوانی ندارد")]
        [Display(Name = "تکرار کلمه عبور")]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage = "لطفا فرمت {0} را درست وارد کنید")]
        [Display(Name = "ایمیل ")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "حداقل 8 کارکتر باید وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کارکتر می توانیدوارد کنید")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
