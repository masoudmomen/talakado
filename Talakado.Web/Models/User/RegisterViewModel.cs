using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Talakado.Web.Models.User
{
    public class RegisterViewModel
    {
        [DisplayName("نام و نام خانوادگی")]
        [Required(ErrorMessage ="نام و نام خانوادگی را وارد نمایید")]
        [MaxLength(100, ErrorMessage ="نام و نام خانوادگی نباید بیشتر از 100 کاراکتر داشته باشد")]
        public string FullName { get; set; }

        [Display(Name ="ایمیل")]
        [Required(ErrorMessage ="ایمیل خود را وارد نمایید")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="رمز عبور خود را وارد نمایید")]
        public string Password { get; set; }

        [Display(Name ="تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="تکرار رمز عبور را وارد نمایید")]
        [Compare(nameof(Password),ErrorMessage ="رمز عبور و تکرار آن باید برابر باشند")]
        public string RePassword { get; set; }

        [Display(Name ="شماره همراه")]
        [AllowNull]
        public string? PhoneNumber { get; set; }
    }
}
