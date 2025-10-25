using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;
    

namespace BookingPR
{
    public partial class FormAdmin : XtraForm
    {
        private Button btnDoanhThu;
        private Button btnSoLuongMon;
        private Button btnClose;

        public FormAdmin()
        {
            InitializeComponent(); // designer method
            InitializeCustomComponents();

            this.Shown += FormAdmin_Shown;
            this.Resize += FormAdmin_Resize;
            // Load event wired in designer will call FormAdmin_Load
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Admin Panel";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(600, 400);

            var lblTitle = new Label
            {
                Text = "Admin Control Panel",
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };

            btnDoanhThu = new Button
            {
                Text = "Doanh thu",
                Width = 160,
                Height = 40
            };
            btnDoanhThu.Click += BtnDoanhThu_Click;

            btnSoLuongMon = new Button
            {
                Text = "Số lượng món",
                Width = 160,
                Height = 40
            };
            btnSoLuongMon.Click += BtnSoLuongMon_Click;

            btnClose = new Button
            {
                Text = "Đóng",
                Width = 100,
                Height = 30
            };
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle);
            this.Controls.Add(btnDoanhThu);
            this.Controls.Add(btnSoLuongMon);
            this.Controls.Add(btnClose);
        }

        // Designer wired Load event expects this method
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            // đảm bảo bố cục đúng khi form load
            LayoutButtons();
        }

        private void FormAdmin_Shown(object sender, EventArgs e)
        {
            LayoutButtons();
        }

        private void FormAdmin_Resize(object sender, EventArgs e)
        {
            LayoutButtons();
        }

        private void LayoutButtons()
        {
            int cx = this.ClientSize.Width / 2;
            int top = 120;

            if (btnDoanhThu != null)
            {
                btnDoanhThu.Left = cx - btnDoanhThu.Width - 10;
                btnDoanhThu.Top = top;
            }

            if (btnSoLuongMon != null)
            {
                btnSoLuongMon.Left = cx + 10;
                btnSoLuongMon.Top = top;
            }

            if (btnClose != null)
            {
                btnClose.Left = (this.ClientSize.Width - btnClose.Width) / 2;
                btnClose.Top = this.ClientSize.Height - btnClose.Height - 20;
            }
        }

        private void BtnDoanhThu_Click(object sender, EventArgs e)
        {
            try
            {
                using (var f = new DoanhThu())
                {
                    f.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở báo cáo Doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSoLuongMon_Click(object sender, EventArgs e)
        {
            try
            {
                using (var f = new SoLuongMon())
                {
                    f.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở báo cáo Số lượng món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}