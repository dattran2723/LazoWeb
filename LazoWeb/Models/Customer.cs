using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazoWeb.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ và tên!")]
        [RegularExpression(@"^(\p{L}+\s?)*$", ErrorMessage = "Họ và tên không chứa số và kí tự đặc biệt!")]
        [StringLength(50)]
        public string Name { get; set; }
        [DisplayName("Tên công ty")]
        [Required(ErrorMessage = "Vui lòng nhập tên công ty!")]
        public string Company { get; set; }

        [DisplayName("Số lượng nhân viên")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng nhân viên!")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng nhập số lượng nhân viên lớn hơn 0!")]
        public int NumberEmployee { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại liên hệ!")]
        [RegularExpression("^[0-9]+$",ErrorMessage ="Vui lòng nhập đúng định dạng!")]
        [StringLength(11,ErrorMessage ="Số điên thoại gồm 10-11 ký tự số!")]
        [MinLength(10,ErrorMessage = "Số điên thoại gồm 10-11 ký tự số!")]
        public string Phone { get; set; }

        [DisplayName("Địa chỉ Email")]
        [Required(ErrorMessage ="Vui lòng nhập Email!")]
        [EmailAddress(ErrorMessage ="Địa chỉ Email không hợp lệ!")]
        public string Email { get; set; }

        [DisplayName("Ngày đăng ký")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegisterDate { get; set; }

        [DisplayName("Ghi chú")]
        public string Description { get; set; }

        [DefaultValue(false)]
        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
    }
}