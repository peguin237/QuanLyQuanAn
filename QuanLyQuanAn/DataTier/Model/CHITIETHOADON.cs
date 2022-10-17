namespace QuanLyQuanAn.DataTier.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [Key]
        public int MACHITIETHD { get; set; }

        public int? MAHD { get; set; }

        public int? MAMON { get; set; }

        public int? SOLUONG { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual MON MON { get; set; }
    }
}
