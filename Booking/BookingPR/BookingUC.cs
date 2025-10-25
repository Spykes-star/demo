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
    public partial class BookingUC : UserControl
    {
        private Booking1 b1;
        private Booking2 b2;
        

        
        public BookingUC()
        {
            InitializeComponent();

            LoadBooking1();
            
            
            this.Dock = DockStyle.Fill;
        }

       

        private void LoadBooking1()
        {
            PanelMain.Controls.Clear();
            b1 = new Booking1();
            b1.OnContinue2 += b1_Continue;
            PanelMain.Controls.Add(b1);
            b1.Dock = DockStyle.Fill;
        }

        private string ten, sdt, ghichu;
        private int songuoi;
        private DateTime gioden;

        private void b1_Continue(string hoTen, string sdt, int soNguoi, DateTime ngayDat, string ghiChu)
        {
            this.ten = hoTen;
            this.sdt = sdt;
            this.songuoi = soNguoi;
            this.gioden = ngayDat;
            this.ghichu = ghiChu;

            PanelMain.Controls.Clear();
            b2 = new Booking2(hoTen, sdt, soNguoi, ngayDat, ghiChu);

            b2.OnContinue3 += B2_OnContinue3;
            PanelMain.Controls.Add(b2);
            
            b2.Dock = DockStyle.Fill;
        }

        private void B2_OnContinue3(string hoTen, string sdt, int soNguoi, DateTime gioden, string ghiChu, List<BookingPR.Data.ChiTietDatBan> dsMon)
        {
            PanelMain.Controls.Clear();

            // 🟢 Chuyển sang Booking3, hiển thị danh sách món ăn
            using (var db = new BookingPR.Data.Model1())
            {
                var dsTuple = dsMon.Select(ct =>
                {
                    var mon = db.MonAn.FirstOrDefault(m => m.MonAnID == ct.MonAnID);
                    return (mon?.TenMon ?? "Không rõ", ct.SoLuong ?? 0, mon?.Gia ?? 0);
                }).ToList();

                var b3 = new Booking3(hoTen, sdt, soNguoi, gioden, ghiChu, dsTuple);
                b3.Dock = DockStyle.Fill;
                PanelMain.Controls.Add(b3);
            }
        }
        private void BookingUC_Load(object sender, EventArgs e)
        {

        }
    }
}
