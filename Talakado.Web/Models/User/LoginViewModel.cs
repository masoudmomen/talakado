using System.ComponentModel.DataAnnotations;

namespace Talakado.Web.Models.User
{
    public class LoginViewModel
    {
        [Display(Name ="ایمیل")]
        [Required(ErrorMessage ="لطفا ایمیل خود را وارد نمایید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد نمایید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="مرا بخاطر بسپار")]
        public bool IsPersistent { get; set; }

        public string ReturnUrl { get; set; }
    }
}
