using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Partner
    {
        [Required(ErrorMessage = "Mời bạn nhập Tài khoản Pay")]
        public long PartnerAccount { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập password")]
        public string Password { get; set; }
        public string Salt { get; set; }
        public long AccountNumber { get; set; }
        public int Status { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
    }
}