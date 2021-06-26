namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [StringLength(250)]
        [Display(Name="Tên sản phẩm")]
        [Required(ErrorMessage ="Bạn chưa nhập tên sản phẩm")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name="Mã")]
        [Required(ErrorMessage = "Bạn chưa nhập mã")]
        public string Code { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bạn chưa nhập tiêu đề")]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Đường dẫn hình")]
        public string Image { get; set; }

        [Display(Name = "Giá tiền")]
        [Required(ErrorMessage = "Bạn chưa nhập giá tiền")]
        public decimal? Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        public decimal? PromotionPrice { get; set; }

        [Display(Name = "VAT")]
        public bool? IncludedVAT { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Số lượng là số nguyên")]
        public int? Quantity { get; set; }

        [Display(Name = "Mã loại")]
        [Required(ErrorMessage = "Bạn chưa nhập mã loại")]
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Thông tin")]
        public string Detail { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        [Display(Name = "Từ khóa SEO")]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [Display(Name = "Miêu tả SEO")]
        public string MetaDescriptions { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }
    }
}
