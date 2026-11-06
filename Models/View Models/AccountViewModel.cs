using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M_Shop.Models.View_Models
{

    //فرم ثبت نام
    public class RegisterViewModel
    {
        [Required (ErrorMessage = "لطفا  {0} را وارد کنید")]
        [Display(Name = "ایمیل")]
        [MaxLength(300)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا  {0} را وارد کنید")]
        [Display(Name = "کلمه عبور")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا  {0} را وارد کنید")]
        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]

        public string RePassword { get; set; }


    }

    public class LoginViewModel
    {

        [Required(ErrorMessage = "لطفا  {0} را وارد کنید")]
        [Display(Name = "ایمیل")]
        [MaxLength(300)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا  {0} را وارد کنید")]
        [Display(Name = "کلمه عبور")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool ReMemberMe { get; set; }
    }
}
