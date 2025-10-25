using BookingPR.Data;
using DevExpress.XtraEditors;
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
    public partial class LichsuUC : DevExpress.XtraEditors.XtraUserControl
    {
        private int? lastKhachHangId = null;
        public LichsuUC()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.VisibleChanged += LichsuUC_VisibleChanged;

        }
        public void RefreshData()
        {
            LoadLS(force: true);
        }

        private void LichsuUC_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible )
            {
                LoadLS();
             

            }
        }
        private void LoadLS(bool force = false)
        {
            try
            {
                var current = LoginUC.CurrentUser.KhachHienTai;
                int? currentId = current?.KhachHangID;
                if (!force && currentId != null && lastKhachHangId == currentId)
                    return;

                // Nếu chưa đăng nhập -> clear grid, không show MessageBox
                if (current == null)
                {
                    dgv1.DataSource = new List<object>();
                    lastKhachHangId = null;
                    return;
                }

                using (var db = new Model1())
                {
                    int khId = current.KhachHangID;

                    var list = db.DatBan
                        .Where(d => d.KhachHang.KhachHangID == khId)
                        .Select(d => new
                        {
                            KhachHang = d.KhachHang.HoTen,
                            SDT = d.KhachHang.SDT,
                            d.SoNguoi,
                            d.GioDat,
                            d.GhiChu,
                            d.TrangThai,
                            TongTien = d.ChiTietDatBan.Sum(ct => (decimal?)ct.SoLuong * ct.MonAn.Gia) ?? 0
                        })
                        .OrderByDescending(d => d.GioDat)
                        .ToList();

                    dgv1.DataSource = list;
                    if (dgv1.Columns.Contains("KhachHang")) dgv1.Columns["KhachHang"].HeaderText = "Khách hàng";
                    if (dgv1.Columns.Contains("SDT")) dgv1.Columns["SDT"].HeaderText = "Số điện thoại";
                    if (dgv1.Columns.Contains("SoNguoi")) dgv1.Columns["SoNguoi"].HeaderText = "Số người";
                    if (dgv1.Columns.Contains("GioDat")) dgv1.Columns["GioDat"].HeaderText = "Giờ đặt";
                    if (dgv1.Columns.Contains("GhiChu")) dgv1.Columns["GhiChu"].HeaderText = "Ghi chú";
                    if (dgv1.Columns.Contains("TrangThai")) dgv1.Columns["TrangThai"].HeaderText = "Trạng thái";
                    if (dgv1.Columns.Contains("TongTien"))
                    {
                        dgv1.Columns["TongTien"].HeaderText = "Tổng tiền";
                        dgv1.Columns["TongTien"].DefaultCellStyle.Format = "N0"; // hoặc "C0" nếu muốn kèm ký hiệu tiền
                        dgv1.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    lastKhachHangId = khId;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi tải lịch sử đặt bàn: " + ex.Message);
            }
        }
        private void LichsuUC_Load(object sender, EventArgs e)
        {
            
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
