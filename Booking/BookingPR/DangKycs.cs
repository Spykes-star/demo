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
using static DevExpress.Data.Helpers.FindSearchRichParser;

namespace BookingPR
{
    public partial class DangKycs : DevExpress.XtraEditors.XtraForm
    {
        public DangKycs()
        {
            InitializeComponent();
            this.Text = "Đăng Ký Khách Hàng Mới!";
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDC.Text.Trim();
            string matKhau = txtMK.Text.Trim();

            if(string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(matKhau))
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new Model1())
            {
                var tontai = db.KhachHang.Any(k => k.SDT == sdt);
                if (tontai)
                {
                    XtraMessageBox.Show("Số điện thoại này đã được đăng ký!", "Thông báo");
                    return;
                }

                var kh = new KhachHang()
                {
                    HoTen = hoTen,
                    SDT = sdt,
                    DiaChi = diaChi,
                    MatKhau = matKhau
                };

                db.KhachHang.Add(kh);
                db.SaveChanges();

                XtraMessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
