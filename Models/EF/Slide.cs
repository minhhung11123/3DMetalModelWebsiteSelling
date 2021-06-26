namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? DisplayOrther { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(50)]
        public string H1 { get; set; }

        [StringLength(50)]
        public string H2 { get; set; }

        public decimal? Prince { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }
    }
}
