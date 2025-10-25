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
        public partial class HomeUC : UserControl
        {
            
            public HomeUC()
            {
                InitializeComponent();
            

                Label lbl = new Label
                {
                    Text = "🏠 Đây là TRANG CHỦ",
                    Dock = DockStyle.Fill,
                    Font = new System.Drawing.Font("Segoe UI", 20, System.Drawing.FontStyle.Bold),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                };
                this.Controls.Add(lbl);
                this.Dock = DockStyle.Fill;
            }

            private void HomeUC_Load(object sender, EventArgs e)
            {

            }
        }
    }
