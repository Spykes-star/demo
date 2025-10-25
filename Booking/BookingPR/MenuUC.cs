
using BookingPR.Data;
using DevExpress.XtraExport.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;    
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BookingPR
{
    public partial class MenuUC : UserControl
    {
        public MenuUC()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            LoadMenu();
        }

        private void LoadMenu()
        {
            flowLayoutPanel1.Controls.Clear();

            using (var db = new Model1()) 
            {
                var list = db.MonAn.ToList();

                foreach (var item in list)
                {
                    Panel pnl = new Panel
                    {
                        Width = 200,
                        Height = 250,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(10)
                    };

                    PictureBox pic = new PictureBox
                    {
                        Width = 180,
                        Height = 150,
                        Left = 10,
                        SizeMode = PictureBoxSizeMode.StretchImage
                        
                    };
                    string imgPath = Path.Combine(Application.StartupPath, "Hinhanh", item.HinhAnh ?? "");
                    if (File.Exists(imgPath))
                    {
                        pic.Image = Image.FromFile(imgPath);
                    }
                    else
                    {
                        Bitmap noImage = new Bitmap(200, 140);
                        using (Graphics g = Graphics.FromImage(noImage))
                        {
                            g.Clear(Color.LightGray);
                            g.DrawString("No Image", new Font("Segoe UI", 10, FontStyle.Italic),
                                Brushes.DarkGray, new PointF(50, 60));
                        }
                        pic.Image = noImage;
                    }

                    Label lblName = new Label
                    {
                        Text = item.TenMon,
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Bottom,
                        Height = 40,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold)
                    };

                    Label lblPrice = new Label
                    {
                        Text = $"{item.Gia:N0} VNĐ",
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Bottom,
                        Height = 30,
                        ForeColor = Color.DarkRed,
                        Font = new Font("Segoe UI", 10, FontStyle.Regular)
                    };

                    pnl.Controls.Add(lblPrice);
                    pnl.Controls.Add(lblName);
                    pnl.Controls.Add(pic);

                    flowLayoutPanel1.Controls.Add(pnl);
                }
            }
        }
        private void MenuUC_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
