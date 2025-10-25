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
    public partial class SoLuongMon : Form
    {
        private RadioButton rbDay;
        private RadioButton rbMonth;
        private DateTimePicker dtPicker;
        private Button btnRun;
        private Panel toolbarPanel;
        private ProgressBar progressBar;
        private bool _autoLoaded = false;

        public SoLuongMon()
        {
            InitializeComponent();
            InitializeToolbar();
            ApplyModernTheme();

            // Auto run when first shown
            this.Shown += SoLuongMon_Shown;
        }

        private async void SoLuongMon_Shown(object sender, EventArgs e)
        {
            if (_autoLoaded) return;
            _autoLoaded = true;
            await RunReportAsync();
        }

        // 💠 Thiết kế Toolbar hiện đại
        private void InitializeToolbar()
        {
            toolbarPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(15, 10, 15, 10)
            };

            // Shadow nhẹ dưới thanh toolbar
            toolbarPanel.Paint += (s, e) =>
            {
                using (var shadow = new LinearGradientBrush(new Rectangle(0, toolbarPanel.Height - 5, toolbarPanel.Width, 5),
                    Color.FromArgb(50, 0, 0, 0), Color.Transparent, 90f))
                {
                    e.Graphics.FillRectangle(shadow, new Rectangle(0, toolbarPanel.Height - 5, toolbarPanel.Width, 5));
                }
            };

            var lblTitle = new Label
            {
                Text = "📊 Báo cáo số lượng món ăn",
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = Color.FromArgb(50, 50, 50),
                Top = 10,
                Left = 10
            };

            rbDay = new RadioButton
            {
                Text = "Theo ngày",
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Left = 15,
                Top = 35,
                Checked = true
            };

            rbMonth = new RadioButton
            {
                Text = "Theo tháng",
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                Left = 130,
                Top = 35
            };

            dtPicker = new DateTimePicker
            {
                Left = 260,
                Top = 32,
                Width = 140,
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10F)
            };

            // Khi chọn month, chuyển về MM/yyyy updown
            rbMonth.CheckedChanged += (s, e) =>
            {
                if (rbMonth.Checked)
                {
                    dtPicker.Format = DateTimePickerFormat.Custom;
                    dtPicker.CustomFormat = "MM/yyyy";
                    dtPicker.ShowUpDown = true;
                }
                else
                {
                    dtPicker.Format = DateTimePickerFormat.Short;
                    dtPicker.ShowUpDown = false;
                }
            };

            btnRun = new Button
            {
                Text = "Chạy báo cáo",
                Left = 420,
                Top = 28,
                Width = 140,
                Height = 30,
                Font = new Font("Segoe UI Semibold", 10F),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRun.FlatAppearance.BorderSize = 0;
            btnRun.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 190);
            btnRun.Click += async (s, e) => await RunReportAsync();

            // ProgressBar nhỏ hiển thị khi đang xử lý
            progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                Left = btnRun.Right + 15,
                Top = 32,
                Width = 120,
                Height = 20,
                Visible = false
            };

            toolbarPanel.Controls.Add(lblTitle);
            toolbarPanel.Controls.Add(rbDay);
            toolbarPanel.Controls.Add(rbMonth);
            toolbarPanel.Controls.Add(dtPicker);
            toolbarPanel.Controls.Add(btnRun);
            toolbarPanel.Controls.Add(progressBar);

            // Nếu reportViewer có sẵn, dock nó bên dưới
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

        // 🎨 Áp dụng theme nhẹ cho Form tổng thể
        private void ApplyModernTheme()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 9F);
            this.Padding = new Padding(5);
        }

        // ⚙️ Sửa: tính toán trên bộ nhớ để tránh lỗi dịch LINQ sang SQL
        private async Task RunReportAsync()
        {
            btnRun.Enabled = false;
            progressBar.Visible = true;
            try
            {
                var rdlcPath = Path.Combine(Application.StartupPath, "Reports", "SoLuongMon.rdlc");
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
                    // Build start/end to be fully translatable by EF
                    DateTime start, end;
                    if (rbDay.Checked)
                    {
                        var date = dtPicker.Value.Date;
                        start = date;
                        end = start.AddDays(1);
                    }
                    else
                    {
                        int month = dtPicker.Value.Month;
                        int year = dtPicker.Value.Year;
                        start = new DateTime(year, month, 1);
                        end = start.AddMonths(1);
                    }

                    // Load DatBan with details into memory, including MonAn
                    var bookings = await db.DatBan
                        .Where(d => d.GioDat >= start && d.GioDat < end)
                        .Include(d => d.ChiTietDatBan.Select(ct => ct.MonAn))
                        .ToListAsync();

                    // Flatten details in memory and compute grouping
                    var details = bookings
                        .SelectMany(d => d.ChiTietDatBan)
                        .Where(ct => ct != null && ct.MonAn != null)
                        .Select(ct => new
                        {
                            TenMon = ct.MonAn.TenMon ?? string.Empty,
                            SoLuong = ct.SoLuong
                        })
                        .ToList();

                    var grouped = details
                        .GroupBy(x => x.TenMon)
                        .Select(g => new
                        {
                            TenMon = g.Key,
                            SoLuong = g.Sum(x => x.SoLuong)
                        })
                        .OrderByDescending(x => x.SoLuong)
                        .ToList();

                    var ds = new ReportDataSource("DishQuantityDataset", grouped);
                    reportViewer1.LocalReport.DataSources.Add(ds);

                    // Set ReportPeriod parameter (DD/MM or MM/YYYY)
                    if (rbDay.Checked)
                        reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportPeriod", $"Ngày: {start:d}"));
                    else
                        reportViewer1.LocalReport.SetParameters(new ReportParameter("ReportPeriod", $"Tháng: {start:MM/yyyy}"));

                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo:\n" + ex.Message + "\n\nStack:\n" + ex.ToString(),
                    "Lỗi báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine("SoLuongMon RunReportAsync error: " + ex.ToString());
            }
            finally
            {
                btnRun.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private void SoLuongMon_Load(object sender, EventArgs e)
        {
            // chờ người dùng nhấn "Chạy báo cáo"
        }
    }
}
