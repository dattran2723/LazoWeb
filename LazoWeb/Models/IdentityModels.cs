using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LazoWeb.Models
{

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [RegularExpression(@"^(\p{L}+\s?)*$", ErrorMessage = "Họ và tên không chứa số và kí tự đặc biệt!")]
        [StringLength(30, ErrorMessage = "Tên nhập vào không được dài quá {2} kí tự.")]
        public string FirstName { get; set; }
        [Display(Name = "Họ")]
        [RegularExpression(@"^(\p{L}+\s?)*$", ErrorMessage = "Họ và tên không chứa số và kí tự đặc biệt!")]
        [Required(ErrorMessage = "Bắt buộc bạn phải nhập vào")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Display(Name = "Ngày tạo tài khoản")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayTao { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<LazoWeb.Models.Customer> Customers { get; set; }

    }
}