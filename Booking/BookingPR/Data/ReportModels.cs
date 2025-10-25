namespace BookingPR.Data
{
    // Báo cáo doanh thu theo ngày hoặc tháng
    public class DoanhThuModel
    {
        public string Ngay { get; set; }
        public int SoLuongHoaDon { get; set; }
        public decimal TongDoanhThu { get; set; }
    }

    // Báo cáo số lượng món ăn được đặt
    public class SoLuongMonAnModel
    {
        public string TenMon { get; set; }
        public int SoLuong { get; set; } = 0;
        public decimal TongTien { get; set; }
    }
}
