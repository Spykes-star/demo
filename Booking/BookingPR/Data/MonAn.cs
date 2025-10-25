namespace BookingPR.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonAn")]
    public partial class MonAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonAn()
        {
            ChiTietDatBan = new HashSet<ChiTietDatBan>();
        }

        public int MonAnID { get; set; }

        [Required]
        [StringLength(100)]
        public string TenMon { get; set; }

        [Column(TypeName = "money")]
        public decimal Gia { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string Loai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatBan> ChiTietDatBan { get; set; }
    }
}
