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
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Tên công ty")]
        [Required(ErrorMessage = "Vui lòng nhập tên công ty!")]
        public string Company { get; set; }

        [DisplayName("Số lượng nhân viên")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng nhân viên!")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng nhập số lượng nhân viên lớn hơn 0!")]
        public int NumberEmployee { get; set; }

        [DisplayName("Địa chỉ liên hệ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ liên hệ!")]
        [StringLength(100)]
        public string Address { get; set; }

        [DisplayName("Địa chỉ Email")]
        [Required(ErrorMessage ="Vui lòng nhập Email!")]
        [EmailAddress(ErrorMessage ="Địa chỉ Email không hợp lệ!")]
        public string Email { get; set; }

        [DefaultValue(false)]
        public bool Status { get; set; }
    }
}