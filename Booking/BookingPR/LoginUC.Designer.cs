namespace BookingPR
{
    partial class LoginUC
    {
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnSignIn;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblForgot;
        private DevExpress.XtraEditors.LabelControl lblNoAccount;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblSignUp;

        private void InitializeComponent()
        {
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnSignIn = new DevExpress.XtraEditors.SimpleButton();
            this.lblForgot = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblNoAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblSignUp = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(148, 52);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(154, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đăng nhập";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(88, 120);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.txtPhone.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Properties.Appearance.Options.UseBorderColor = true;
            this.txtPhone.Properties.Appearance.Options.UseFont = true;
            this.txtPhone.Properties.AutoHeight = false;
            this.txtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPhone.Properties.NullValuePrompt = "Phone";
            this.txtPhone.Size = new System.Drawing.Size(262, 40);
            this.txtPhone.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(88, 180);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Properties.Appearance.Options.UseBorderColor = true;
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.AutoHeight = false;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPassword.Properties.NullValuePrompt = "Password";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(262, 40);
            this.txtPassword.TabIndex = 2;
            // 
            // btnSignIn
            // 
            this.btnSignIn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnSignIn.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.btnSignIn.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSignIn.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnSignIn.Appearance.Options.UseBackColor = true;
            this.btnSignIn.Appearance.Options.UseFont = true;
            this.btnSignIn.Appearance.Options.UseForeColor = true;
            this.btnSignIn.Location = new System.Drawing.Point(88, 260);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(262, 45);
            this.btnSignIn.TabIndex = 4;
            this.btnSignIn.Text = "Đăng nhập";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lblForgot
            // 
            this.lblForgot.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblForgot.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblForgot.Appearance.Options.UseFont = true;
            this.lblForgot.Appearance.Options.UseForeColor = true;
            this.lblForgot.Location = new System.Drawing.Point(271, 225);
            this.lblForgot.Name = "lblForgot";
            this.lblForgot.Size = new System.Drawing.Size(106, 20);
            this.lblForgot.TabIndex = 3;
            this.lblForgot.Text = "Forgot password";
            this.lblForgot.Click += new System.EventHandler(this.lblForgot_Click);
            // 
            // lblNoAccount
            // 
            this.lblNoAccount.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNoAccount.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblNoAccount.Appearance.Options.UseFont = true;
            this.lblNoAccount.Appearance.Options.UseForeColor = true;
            this.lblNoAccount.Location = new System.Drawing.Point(131, 320);
            this.lblNoAccount.Name = "lblNoAccount";
            this.lblNoAccount.Size = new System.Drawing.Size(153, 20);
            this.lblNoAccount.TabIndex = 5;
            this.lblNoAccount.Text = "Bạn chưa có tài khoàn?";
            // 
            // lblSignUp
            // 
            this.lblSignUp.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSignUp.Appearance.ForeColor = System.Drawing.Color.Orange;
            this.lblSignUp.Appearance.Options.UseFont = true;
            this.lblSignUp.Appearance.Options.UseForeColor = true;
            this.lblSignUp.Location = new System.Drawing.Point(290, 320);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(57, 20);
            this.lblSignUp.TabIndex = 6;
            this.lblSignUp.Text = "Đăng ký";
            this.lblSignUp.Click += new System.EventHandler(this.lblSignUp_Click);
            // 
            // LoginUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblForgot);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.lblNoAccount);
            this.Controls.Add(this.lblSignUp);
            this.Name = "LoginUC";
            this.Size = new System.Drawing.Size(438, 400);
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
