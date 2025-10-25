namespace BookingPR
{
    partial class Booking1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.numSoNguoi = new DevExpress.XtraEditors.SpinEdit();
            this.dtGioDen = new DevExpress.XtraEditors.DateEdit();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.btTiepTuc = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SĐT = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGioDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGioDen.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(235, 63);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.AutoHeight = false;
            this.txtHoTen.Size = new System.Drawing.Size(155, 34);
            this.txtHoTen.TabIndex = 0;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(234, 125);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.AutoHeight = false;
            this.txtSDT.Size = new System.Drawing.Size(155, 34);
            this.txtSDT.TabIndex = 0;
            // 
            // numSoNguoi
            // 
            this.numSoNguoi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numSoNguoi.Location = new System.Drawing.Point(235, 202);
            this.numSoNguoi.Name = "numSoNguoi";
            this.numSoNguoi.Properties.AutoHeight = false;
            this.numSoNguoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.numSoNguoi.Size = new System.Drawing.Size(155, 32);
            this.numSoNguoi.TabIndex = 1;
            // 
            // dtGioDen
            // 
            this.dtGioDen.EditValue = null;
            this.dtGioDen.Location = new System.Drawing.Point(234, 262);
            this.dtGioDen.Name = "dtGioDen";
            this.dtGioDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtGioDen.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtGioDen.Size = new System.Drawing.Size(154, 22);
            this.dtGioDen.TabIndex = 2;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(235, 300);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(159, 47);
            this.txtNote.TabIndex = 3;
            // 
            // btTiepTuc
            // 
            this.btTiepTuc.Location = new System.Drawing.Point(235, 376);
            this.btTiepTuc.Name = "btTiepTuc";
            this.btTiepTuc.Size = new System.Drawing.Size(109, 49);
            this.btTiepTuc.TabIndex = 4;
            this.btTiepTuc.Text = "Tiếp tục";
            this.btTiepTuc.Click += new System.EventHandler(this.btTiepTuc_Click);
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(85, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Họ tên";
            // 
            // SĐT
            // 
            this.SĐT.Enabled = false;
            this.SĐT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SĐT.Location = new System.Drawing.Point(85, 127);
            this.SĐT.Name = "SĐT";
            this.SĐT.Size = new System.Drawing.Size(115, 32);
            this.SĐT.TabIndex = 5;
            this.SĐT.Text = "Số diện thoại";
            // 
            // label3
            // 
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(85, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số người";
            // 
            // label4
            // 
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(85, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "Giờ đến";
            // 
            // label5
            // 
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(85, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ghi chú";
            // 
            // Booking1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SĐT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btTiepTuc);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.dtGioDen);
            this.Controls.Add(this.numSoNguoi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtHoTen);
            this.Name = "Booking1";
            this.Size = new System.Drawing.Size(500, 494);
            this.Load += new System.EventHandler(this.Booking1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGioDen.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGioDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.SpinEdit numSoNguoi;
        private DevExpress.XtraEditors.DateEdit dtGioDen;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.SimpleButton btTiepTuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SĐT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
