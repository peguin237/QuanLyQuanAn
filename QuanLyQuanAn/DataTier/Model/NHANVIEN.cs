namespace QuanLyQuanAn.DataTier.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        public int MANV { get; set; }

        [StringLength(100)]
        public string TEN { get; set; }

        [StringLength(100)]
        public string GIOITINH { get; set; }

        public int? SDT { get; set; }

        [StringLength(500)]
        public string MATKHAU { get; set; }

        [StringLength(100)]
        public string TENDANGNHAP { get; set; }

        [StringLength(50)]
        public string QUYEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
