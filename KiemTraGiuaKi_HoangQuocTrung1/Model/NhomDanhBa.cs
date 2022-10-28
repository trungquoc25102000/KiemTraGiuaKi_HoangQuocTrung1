namespace KiemTraGiuaKi_HoangQuocTrung1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomDanhBa")]
    public partial class NhomDanhBa
    {
        [Key]
        public int MaNhom { get; set; }

        [StringLength(50)]
        public string TenNhom { get; set; }
    }
}
