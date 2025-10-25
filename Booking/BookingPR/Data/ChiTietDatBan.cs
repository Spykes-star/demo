namespace BookingPR.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDatBan")]
    public partial class ChiTietDatBan
    {
        [Key]
        public int ChiTietID { get; set; }

        public int DatBanID { get; set; }

        public int MonAnID { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual DatBan DatBan { get; set; }

        public virtual MonAn MonAn { get; set; }
    }
}
