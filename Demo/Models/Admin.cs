namespace Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        public int idAdmin { get; set; }

        [StringLength(50)]
        public string ten { get; set; }

        [StringLength(40)]
        public string anh { get; set; }

        [StringLength(10)]
        public string gioitinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

        [StringLength(11)]
        public string sdt { get; set; }

        [StringLength(200)]
        public string diachi { get; set; }

        [StringLength(40)]
        public string email { get; set; }

        [StringLength(30)]
        public string matkhau { get; set; }

        [StringLength(12)]
        public string cmnd { get; set; }

        public int? status { get; set; }

        public int? type { get; set; }

        public DateTime? ngaytao { get; set; }

        public DateTime? ngaycapnhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
