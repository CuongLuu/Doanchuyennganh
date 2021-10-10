namespace Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMT")]
    public partial class CMT
    {
        [Key]
        public int maCMT { get; set; }

        public int maND { get; set; }

        public int maSP { get; set; }

        [Column("cmt")]
        [StringLength(1000)]
        public string cmt1 { get; set; }

        public int idAdmin { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
