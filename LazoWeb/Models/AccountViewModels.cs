using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LazoWeb.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email !")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu !")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email !")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu !")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2}.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại mât khẩu !")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2}.", MinimumLength = 1)]
        [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu nhập lại không trùng nhau.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ")]
        [RegularExpression(@"^(\p{L}+\s?)*$", ErrorMessage = "Họ không chứa số và kí tự đặc biệt!")]
        [Required(ErrorMessage = "Vui lòng nhập vào họ !")]
        [StringLength(30, ErrorMessage = "Họ nhập vào không được dài quá {2} kí tự.")]
        public string LastName { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Vui lòng nhập vào tên !")]
        [RegularExpression(@"^(\p{L}+\s?)*$", ErrorMessage = "Tên không chứa số và kí tự đặc biệt!")]
        [StringLength(30, ErrorMessage = "Tên nhập vào không được dài quá {2} kí tự.")]
        public string FirstName { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email !")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu !")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2}.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu !")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2}.", MinimumLength = 1)]
        [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu nhập lại không trùng nhau.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email !")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
