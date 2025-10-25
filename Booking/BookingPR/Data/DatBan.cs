namespace BookingPR.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatBan")]
    public partial class DatBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatBan()
        {
            ChiTietDatBan = new HashSet<ChiTietDatBan>();
        }

        public int DatBanID { get; set; }

        public int KhachHangID { get; set; }

        public int? SoNguoi { get; set; }

        public DateTime GioDat { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatBan> ChiTietDatBan { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
