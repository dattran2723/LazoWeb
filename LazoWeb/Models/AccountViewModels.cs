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
        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2}.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2}.", MinimumLength = 1)]
        [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu nhập lại không trùng nhau.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Họ")]
        [RegularExpression(@"^([a-zA-Z\d ]+[\w\d]*|)[a-zA-Z]+[\w\d.]*$", ErrorMessage = "Tên không chứa số và kí tự đặc biệt")]
        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [RegularExpression(@"^([a-zA-Z\d ]+[\w\d]*|)[a-zA-Z]+[\w\d.]*$", ErrorMessage = "Tên không chứa số và kí tự đặc biệt")]
        [StringLength(30, ErrorMessage = "Tên nhập vào không được dài quá {2} kí tự.")]
        public string FirstName { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2}.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải dài ít nhất {2}.", MinimumLength = 1)]
        [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu nhập lại không trùng nhau.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
