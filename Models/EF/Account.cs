namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public long ID { get; set; }

        [StringLength(32)]
        [Required(ErrorMessage ="Nhập tên tài khoản")]
        [Display(Name="Tài khoản")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Required(ErrorMessage ="Nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [StringLength(10)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(20)]
        [Display(Name = "Thành phố")]
        public string City { get; set; }

        [StringLength(20)]
        [Display(Name = "Quốc gia")]
        public string Country { get; set; }

        [StringLength(10)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Loại")]
        public bool? Type { get; set; }
    }
}
