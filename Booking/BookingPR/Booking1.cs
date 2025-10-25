using BookingPR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingPR
{
    public partial class Booking1 : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void ContinueB2(string hoTen, string sdt, int soNguoi, DateTime ngayDat, string ghiChu);
        public event ContinueB2 OnContinue2;

        //private KhachHang khDangnhap;
        public Booking1(/*KhachHang kh = null*/)
        {
            InitializeComponent();
            /*khDangnhap = kh;
            if (khDangnhap != null)
            {
                txtHoTen.Text = khDangnhap.HoTen;
                txtSDT.Text = khDangnhap.SDT;
            }*/
           // HienThiBooking1();
        }

        private void HienThiBooking1()
        {
            var bk1 = new Booking1();
            bk1.Dock = DockStyle.Fill;
            bk1.OnContinue2 += Booking1_OnContinue2; // 🟢 Gắn sự kiện để chuyển sang Booking2
            this.Controls.Clear();
            this.Controls.Add(bk1);
        }
        private void Booking1_OnContinue2(string hoTen, string sdt, int soNguoi, DateTime gioden, string ghiChu)
        {
            var bk2 = new Booking2(hoTen, sdt, soNguoi, gioden, ghiChu);
            bk2.Dock = DockStyle.Fill;
            bk2.OnContinue3 += Booking2_OnContinue3; // 🟢 Gắn sự kiện để chuyển sang Booking3
            this.Controls.Clear();
            this.Controls.Add(bk2);
        }
        private void Booking2_OnContinue3(string hoTen, string sdt, int soNguoi, DateTime gioden, string ghiChu, List<ChiTietDatBan> dsChiTiet)
        {
            using (var db = new BookingPR.Data.Model1())
            {
                // Chuyển từ ChiTietDatBan -> tuple (TenMon, SoLuong, Gia)
                var dsTuple = dsChiTiet.Select(ct =>
                {
                    var mon = db.MonAn.FirstOrDefault(m => m.MonAnID == ct.MonAnID);
                    return (mon?.TenMon ?? "Không rõ", ct.SoLuong ?? 0, mon?.Gia ?? 0);
                }).ToList();

                var bk3 = new Booking3(hoTen, sdt, soNguoi, gioden, ghiChu, dsTuple);
                bk3.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(bk3);
            }
        }
        private void Booking1_Load(object sender, EventArgs e)
        {

        }

        private void btTiepTuc_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(numSoNguoi.Value < 1)
            {
                MessageBox.Show("Số người phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtGioDen.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn giờ đến!", "Thông báo");
                return;
            }

            DateTime gioDen = Convert.ToDateTime(dtGioDen.EditValue);
            if (gioDen < DateTime.Now)
            {
                MessageBox.Show("Giờ đến phải lớn hơn thời gian hiện tại!", "Thông báo");
                return;
            }

            OnContinue2?.Invoke( txtHoTen.Text.Trim(), txtSDT.Text.Trim(), (int)numSoNguoi.Value, dtGioDen.DateTime, txtNote.Text.Trim()
            );
        }
    }
}
