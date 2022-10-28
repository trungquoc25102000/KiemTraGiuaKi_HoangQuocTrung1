namespace KiemTraGiuaKi_HoangQuocTrung1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietLienLac")]
    public partial class ChiTietLienLac
    {
        [Key]
        public int MaLienLac { get; set; }

        [StringLength(50)]
        public string TenLienLac { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        public int MaNhom { get; set; }
    }
}
