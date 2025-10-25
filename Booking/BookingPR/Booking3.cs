using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingPR
{
    public partial class Booking3 : UserControl
    {
        private string ten, sdt, ghiChu;
        private int soNguoi;
        private DateTime gioDen;
        private List<(string tenMon, int soLuong, decimal donGia)> dsMon;

        private bool isProcessing = false;
        public Booking3(string hoTen, string soDT, int soNguoi, DateTime gioDen, string ghiChu, List<(string, int, decimal)> dsMon)
        {
            
            InitializeComponent();
            this.ten = hoTen;
            this.sdt = soDT;
            this.soNguoi = soNguoi;
            this.gioDen = gioDen;
            this.ghiChu = ghiChu;
            this.dsMon = dsMon;
            LoadData();
        }

        private void LoadData()
        {
            lblHoTen.Text = $"Họ tên: {ten}";
            lblSDT.Text = $"Số điện thoại: {sdt}";
            lblSoNguoi.Text = $"Số người: {soNguoi}";
            lblGioDen.Text = $"Giờ đến: {gioDen.ToString("g")}";
            lblGhiChu.Text = $"Ghi chú: {ghiChu}";
            
            dgvMonAn.DataSource = dsMon.Select(m => new
            {
                Tên_Món = m.tenMon,
                Số_Lượng = m.soLuong,
                Đơn_Giá = m.donGia,
                Thành_Tiền = m.soLuong * m.donGia
            }).ToList();

            decimal tongtien = dsMon.Sum(m => m.soLuong * m.donGia);
            lblTongTien.Text = $"Tổng tiền: {tongtien:C}";
        }
        private void Booking3_Load(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as Form1;
            if (mainForm != null)
            {
                try
                {
                    mainForm.navigationFrame1.SelectedPage = mainForm.pageHome;
                    return;
                }
                catch { }
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (isProcessing) return; // đang xử lý rồi => thoát
            isProcessing = true;
            btnXacNhan.Enabled = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T75S7M6;Initial Catalog=QLDatBan;Integrated Security=True"))
                {
                    conn.Open();

                    SqlCommand cmdKH = new SqlCommand("SELECT KhachHangID FROM KhachHang WHERE SDT = @sdt", conn);
                    cmdKH.Parameters.AddWithValue("@sdt", sdt);
                    object result = cmdKH.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng này!", "Lỗi");
                        return;
                    }
                    int khID = (int)result;

                    SqlCommand cmdDatBan = new SqlCommand(
                        "INSERT INTO DatBan (KhachHangID, SoNguoi, GioDat, GhiChu, TrangThai) OUTPUT INSERTED.DatBanID VALUES (@kh, @so, @gio, @gc, N'Đã xác nhận')", conn);
                    cmdDatBan.Parameters.AddWithValue("@kh", khID);
                    cmdDatBan.Parameters.AddWithValue("@so", soNguoi);
                    cmdDatBan.Parameters.AddWithValue("@gio", gioDen);
                    cmdDatBan.Parameters.AddWithValue("@gc", ghiChu);
                    int datBanID = (int)cmdDatBan.ExecuteScalar();

                    foreach (var mon in dsMon)
                    {
                        SqlCommand cmdCT = new SqlCommand(
                            "INSERT INTO ChiTietDatBan (DatBanID, MonAnID, SoLuong) SELECT @db, MonAnID, @sl FROM MonAn WHERE TenMon = @ten", conn);
                        cmdCT.Parameters.AddWithValue("@db", datBanID);
                        cmdCT.Parameters.AddWithValue("@ten", mon.tenMon);
                        cmdCT.Parameters.AddWithValue("@sl", mon.soLuong);
                        cmdCT.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đặt bàn thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đặt bàn: " + ex.Message);
            }
            finally
            {
                isProcessing = false;
                btnXacNhan.Enabled = true;
            }
        }

        private void dgvMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
                this.Dispose();
            }
        }
    }
}
