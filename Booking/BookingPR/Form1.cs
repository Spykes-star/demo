using BookingPR.Data;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookingPR
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pageHome.Controls.Add(new HomeUC() { Dock = DockStyle.Fill });
            pageMenu.Controls.Add(new MenuUC() { Dock = DockStyle.Fill });
            pageBooking.Controls.Add(new BookingUC() { Dock = DockStyle.Fill });
            pageHistory.Controls.Add(new LichsuUC() { Dock = DockStyle.Fill });
            //pageLogin.Controls.Add(new LoginUC() { Dock = DockStyle.Fill });

            var loginUC = new LoginUC() { Dock = DockStyle.Fill };
            loginUC.OnLoginSuccess += LoginUC_OnLoginSuccess;
            pageLogin.Controls.Add(loginUC);

            navigationFrame1.SelectedPage = pageHome;
        }

        private void LoginUC_OnLoginSuccess(BookingPR.Data.KhachHang kh)
        {
            // ✅ Khi đăng nhập thành công, chuyển sang trang Home
            navigationFrame1.SelectedPage = pageHome;

            MessageBox.Show($"Chào mừng {kh.HoTen}!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void navigationFrame1_Click(object sender, EventArgs e)
        {
            
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageHome;
        }

        private void btMenu_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageMenu;
        }

        private void btDat_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageBooking;

        }
        private void btHistory_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageHistory;
        }
        

        private void btLogin_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage=pageLogin;
        }
    }
}
