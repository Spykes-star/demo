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
    public partial class LoginUC : XtraUserControl
    {
        public delegate void LoginSuccessHandler(KhachHang kh);
        public event LoginSuccessHandler OnLoginSuccess;
        public LoginUC()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void LoginUC_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string sdt = txtPhone.Text.Trim();
            string matkhau = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(sdt) || string.IsNullOrWhiteSpace(matkhau))
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ số điện thoại và mật khẩu.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new Model1())
                {
                    var kh = db.KhachHang.FirstOrDefault(k => k.SDT == sdt && k.MatKhau == matkhau);

                    if (kh != null)
                    {
                        // ✅ Lưu thông tin khách hàng đăng nhập
                        CurrentUser.KhachHienTai = kh;

                        XtraMessageBox.Show($"Đăng nhập thành công! Xin chào {kh.HoTen}.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 🔄 Kích hoạt event để mở BookingUC
                        OnLoginSuccess?.Invoke(kh);
                        var mainForm = this.FindForm() as Form1;
                        if (mainForm != null)
                        {
                            mainForm.navigationFrame1.SelectedPage = mainForm.pageHome;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Số điện thoại hoặc mật khẩu không đúng.",
                            "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi khi đăng nhập: " + ex.Message);
            }
        }

        public static class CurrentUser
        {
            public static KhachHang KhachHienTai { get; set; }
        }
        private void lblForgot_Click(object sender, EventArgs e)
        {

        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            var frmDangKy = new DangKycs();
            if(frmDangKy.ShowDialog() == DialogResult.OK)
            {
                XtraMessageBox.Show("Bạn đã đăng ký thành công! Vui lòng đăng nhập.", "Thông báo");
            }
        }
    }
}
