namespace QuanLyQuanAn.DataTier.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHMUC")]
    public partial class DANHMUC
    {
        [Key]
        public int MADANHMUC { get; set; }

        [StringLength(10)]
        public string TEN { get; set; }
    }
}
