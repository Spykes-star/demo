using BookingPR.Data;
using Microsoft.Reporting.WinForms;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace BookingPR
{
    public partial class DoanhThu : Form
    {
        private RadioButton rbDay;
        private RadioButton rbMonth;
        private DateTimePicker dtPicker;
        private Button btnRun;
        private Panel toolbarPanel;
        private ProgressBar progressBar;
        private bool _autoLoaded = false;

        public DoanhThu()
        {
            InitializeComponent();
            InitializeToolbar();
            ApplyModernTheme();

            this.Shown += DoanhThu_Shown;
        }

        private async void DoanhThu_Shown(object sender, EventArgs e)
        {
            if (_autoLoaded) return;
            _autoLoaded = true;
            await RunReportAsync();
        }

        private void InitializeToolbar()
        {
            // 🔷 Panel chính trên cùng
            toolbarPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 65,
                BackColor = Color.White,
                Padding = new Padding(15, 10, 15, 10)
            };

            toolbarPanel.Paint += (s, e) =>
            {
                using (var shadow = new LinearGradientBrush(
                    new Rectangle(0, toolbarPanel.Height - 6, toolbarPanel.Width, 6),
                    Color.FromArgb(50, 0, 0, 0), Color.Transparent, 90f))
                {
                    e.Graphics.FillRectangle(shadow, new Rectangle(0, toolbarPanel.Height - 6, toolbarPanel.Width, 6));
                }
            };

            // 🧾 Tiêu đề
            var lblTitle = new Label
            {
                Text = "💰 Báo cáo doanh thu",
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = Color.FromArgb(45, 45, 45),
                Left = 12,
                Top = 8
            };

            rbDay = new RadioButton
            {
                Text = "Theo ngày",
                Font = new Font("Segoe UI", 10F),
                Left = 15,
                Top = 36,
                Checked = true
            };

            rbMonth = new RadioButton
            {
                Text = "Theo tháng",
                Font = new Font("Segoe UI", 10F),
                Left = 130,
                Top = 36
            };

            dtPicker = new DateTimePicker
            {
                Left = 260,
                Top = 33,
                Width = 140,
                Font = new Font("Segoe UI", 10F),
                Format = DateTimePickerFormat.Short
            };

            // switch picker format when selecting month mode
            rbDay.CheckedChanged += (s, e) =>
            {
                if (rbDay.Checked)
                {
                    dtPicker.Format = DateTimePickerFormat.Short;
                    dtPicker.ShowUpDown = false;
                }
            };
            rbMonth.CheckedChanged += (s, e) =>
            {
                if (rbMonth.Checked)
                {
                    dtPicker.Format = DateTimePickerFormat.Custom;
                    dtPicker.CustomFormat = "MM/yyyy";
                    dtPicker.ShowUpDown = true;
                }
            };

            btnRun = new Button
            {
                Text = "Chạy báo cáo",
                Left = 420,
                Top = 30,
                Width = 140,
                Height = 32,
                Font = new Font("Segoe UI Semibold", 10F),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRun.FlatAppearance.BorderSize = 0;
            btnRun.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 220);
            btnRun.Click += async (s, e) => await RunReportAsync();

            // 🔄 Progress hiển thị khi đang xử lý
            progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                Left = btnRun.Right + 20,
                Top = 36,
                Width = 130,
                Height = 20,
                Visible = false
            };

            // Thêm các control vào panel
            toolbarPanel.Controls.Add(lblTitle);
            toolbarPanel.Controls.Add(rbDay);
            toolbarPanel.Controls.Add(rbMonth);
            toolbarPanel.Controls.Add(dtPicker);
            toolbarPanel.Controls.Add(btnRun);
            toolbarPanel.Controls.Add(progressBar);

            // Gắn panel vào Form
            if (this.Controls.Contains(reportViewer1))
            {
                reportViewer1.Dock = DockStyle.Fill;
                this.Controls.Add(toolbarPanel);
                this.Controls.SetChildIndex(toolbarPanel, 0);
            }
            else
            {
                this.Controls.Add(toolbarPanel);
            }
        }

        private void ApplyModernTheme()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 9F);
            this.Padding = new Padding(5);
        }

        // ⚙️ Sửa: materialize dữ liệu rồi tính toán trong memory
        private async Task RunReportAsync()
        {
            btnRun.Enabled = false;
            progressBar.Visible = true;
            try
            {
                var rdlcPath = Path.Combine(Application.StartupPath, "Reports", "DoanhThu.rdlc");
                if (!File.Exists(rdlcPath))
                {
                    MessageBox.Show($"File báo cáo không tìm thấy:\n{rdlcPath}\n\nSet Build Action = Content và Copy to Output Directory = Copy if newer.",
                        "File RDLC thiếu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reportViewer1.Reset();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = rdlcPath;
                reportViewer1.LocalReport.DataSources.Clear();

                using (var db = new Model1())
                {
                    DateTime start, end;
                    if (rbDay.Checked)
                    {
                        var date = dtPicker.Value.Date;
                        start = date;
                        end = start.AddDays(1);

                        // load orders with details and customer
                        var bookings = await db.DatBan
                            .Where(d => d.GioDat >= start && d.GioDat < end)
                            .Include(d => d.KhachHang)
                            .Include(d => d.ChiTietDatBan.Select(ct => ct.MonAn))
                            .ToListAsync();

                        var orders = bookings.Select(d => new
                        {
                            DatBanID = d.DatBanID,
                            KhachHang = d.KhachHang?.HoTen ?? string.Empty,
                            GioDat = d.GioDat,
                            TongTien = d.ChiTietDatBan?.Sum(ct => (decimal)(ct.SoLuong) * ct.MonAn.Gia) ?? 0m
                        }).OrderByDescending(x => x.GioDat).ToList();

                        var ds = new ReportDataSource("OrdersDataset", orders);
                        reportViewer1.LocalReport.DataSources.Add(ds);
                        reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportPeriod", $"Ngày: {start:d}"));
                    }
                    else
                    {
                        int month = dtPicker.Value.Month;
                        int year = dtPicker.Value.Year;
                        start = new DateTime(year, month, 1);
                        end = start.AddMonths(1);

                        var bookings = await db.DatBan
                            .Where(d => d.GioDat >= start && d.GioDat < end)
                            .Include(d => d.ChiTietDatBan.Select(ct => ct.MonAn))
                            .ToListAsync();

                        var details = bookings
                            .SelectMany(d => d.ChiTietDatBan)
                            .Where(ct => ct != null && ct.MonAn != null)
                            .Select(ct => new
                            {
                                Date = DbFunctions.TruncateTime(ct.DatBan.GioDat) ?? DbFunctions.TruncateTime(ct.DatBan.GioDat),
                                Amount = (decimal)ct.SoLuong * ct.MonAn.Gia,
                                DateValue = ct.DatBan.GioDat.Date
                            })
                            .ToList();

                        var daily = details
                            .GroupBy(x => x.DateValue)
                            .Select(g => new
                            {
                                Ngay = g.Key.ToString("d"),
                                DoanhThu = g.Sum(x => x.Amount)
                            })
                            .OrderBy(x => x.Ngay)
                            .ToList();

                        var ds = new ReportDataSource("DailyRevenueDataset", daily);
                        reportViewer1.LocalReport.DataSources.Add(ds);
                        reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportPeriod", $"Tháng: {start:MM/yyyy}"));
                    }

                    try
                    {
                        reportViewer1.RefreshReport();
                    }
                    catch (Exception rex)
                    {
                        // Detailed info from report processing
                        var inner = rex.InnerException != null ? rex.InnerException.Message : "<no inner>";
                        MessageBox.Show($"Lỗi khi xử lý report:\n{rex.Message}\nInner: {inner}\n\nXem Output/Debug để biết stacktrace.",
                            "Lỗi report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Diagnostics.Debug.WriteLine("Report processing error: " + rex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo:\n" + ex.Message + "\n\nInner:\n" + (ex.InnerException?.Message ?? "<none>") + "\n\nStack:\n" + ex.ToString(),
                    "Lỗi báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine("DoanhThu RunReportAsync error: " + ex.ToString());
            }
            finally
            {
                btnRun.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            // chờ người dùng nhấn "Chạy báo cáo"
        }
    }
}
    