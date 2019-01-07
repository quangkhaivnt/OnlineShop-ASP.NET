using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }

        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name="Mật khẩu")]
        [StringLength(30,MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhập lại mật khẩu")]
        [Display(Name="Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [Display(Name="Họ và tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [Display(Name="Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name="Điện thoại")]
        public string Phone { get; set; }

    }
}