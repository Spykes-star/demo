using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookingPR.Data
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=BookingContext")
        {
        }

        public virtual DbSet<ChiTietDatBan> ChiTietDatBan { get; set; }
        public virtual DbSet<DatBan> DatBan { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<MonAn> MonAn { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DatBan)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .Property(e => e.Gia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.ChiTietDatBan)
                .WithRequired(e => e.MonAn)
                .WillCascadeOnDelete(false);
        }
    }
}
