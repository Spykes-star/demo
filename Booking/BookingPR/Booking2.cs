using BookingPR.Data;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BookingPR
{
    public partial class Booking2 : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void Continue3Handler(string hoTen, string sdt, int soNguoi, DateTime gioden, string ghiChu, List<ChiTietDatBan> dsMon);
        public event Continue3Handler OnContinue3;

         private List<ChiTietDatBan> danhSachMon = new List<ChiTietDatBan>();

        private string ten;
        private string sdt;
        private int soNguoi;
        private DateTime gioden;
        private string ghiChu;

        public Booking2(string hoTen, string sdt, int soNguoi, DateTime gioden, string ghiChu)
        {
            InitializeComponent(); 
            this.ten = hoTen;
            this.sdt = sdt;
            this.soNguoi = soNguoi;
            this.gioden = gioden;
            this.ghiChu = ghiChu;

        }

        private void Booking2_Load_1(object sender, EventArgs e)
        {
        }

        private void LoadMenu()
        {
            using (var db = new Model1())
            {
                var monAnList = db.MonAn.ToList();
                
                foreach (var mon in monAnList)
                {
                    Panel pnl = new Panel()
                    {
                        Width = 350,
                        Height = 100,
                        Margin = new Padding(8),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    PictureBox pic = new PictureBox()
                    {
                        Width = 90,
                        Height = 80,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Left = 5,
                        Top = 10
                    };

                    if (!string.IsNullOrEmpty(mon.HinhAnh))
                    {
                        // Ghép đường dẫn đến thư mục images
                        string imageFolder = System.IO.Path.Combine(Application.StartupPath, "Hinhanh");
                        string path = System.IO.Path.Combine(imageFolder, mon.HinhAnh);

                        // Nếu file ảnh tồn tại thì load
                        if (System.IO.File.Exists(path))
                        {
                            try
                            {
                                pic.Image = Image.FromFile(path);
                            }
                            catch (Exception ex)
                            {
                                // Nếu lỗi khi đọc ảnh => hiển thị thông báo tạm thời
                                Console.WriteLine($"⚠️ Không thể đọc ảnh {path}: {ex.Message}");
                                pic.BackColor = Color.LightGray;
                                pic.Image = null;
                            }
                        }
                        else
                        {
                            // Ảnh không tồn tại trong thư mục => báo đường dẫn sai
                            Console.WriteLine($"❌ Không tìm thấy ảnh: {path}");
                            pic.BackColor = Color.LightGray;
                            pic.Image = null;
                        }
                    }
                    else
                    {
                        // mon.HinhAnh = null hoặc trống => hiển thị khung rỗng
                        pic.BackColor = Color.LightGray;
                        pic.Image = null;
                        Console.WriteLine($"⚠️ Món '{mon.TenMon}' chưa có ảnh trong DB.");
                    }

                    Label lblTenMon = new Label()
                    {
                        Text = mon.TenMon,
                        AutoSize = true,
                        Left = 100,
                        Top = 10,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold)
                    };

                    Label lblGia = new Label()
                    {
                        Text = $"{mon.Gia:N0} đ",
                        AutoSize = true,
                        Left = 100,
                        Top = 40,
                        ForeColor = Color.DarkRed
                    };
                   lblGia.Tag = mon.Gia;

                    SpinEdit spSoLuong = new SpinEdit()
                    {
                        Left = 250,
                        Top = 30,
                        Width = 70,
                        Value = 0

                    };
                    

                    spSoLuong.Properties.MinValue = 0;
                    spSoLuong.Properties.MaxValue = 20;
                    spSoLuong.Properties.IsFloatValue = false;
                    spSoLuong.Properties.Increment = 1;
                    spSoLuong.Tag = mon.MonAnID;

                    pnl.Controls.Add(pic);
                    pnl.Controls.Add(lblTenMon);
                    pnl.Controls.Add(lblGia);
                    pnl.Controls.Add(spSoLuong);

                    flowMenu.Controls.Add(pnl);

                    
                }
               
            }
           
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            danhSachMon.Clear();
            foreach (Control c in flowMenu.Controls)
            {
                SpinEdit spin = c.Controls.OfType<SpinEdit>().FirstOrDefault();
                if (spin != null)
                {
                    int soLuong = Convert.ToInt32(spin.Value);

                    if (soLuong > 0)
                    {
                        int monID = Convert.ToInt32(spin.Tag);

                        // Thêm vào danh sách
                        danhSachMon.Add(new ChiTietDatBan
                        {
                            MonAnID = monID,
                            SoLuong = soLuong
                        });
                    }
            }
                
            }
            if (danhSachMon.Count == 0)
            {
                DialogResult dr = XtraMessageBox.Show("Bạn chưa chọn món nào. Tiếp tục không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                    return;
            }

            OnContinue3?.Invoke(ten, sdt, soNguoi, gioden, ghiChu, danhSachMon);
        }

        private void flowMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void Booking2_Load(object sender, EventArgs e)
        {
            LoadMenu();
        }
    }
}
