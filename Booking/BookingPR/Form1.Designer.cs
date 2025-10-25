namespace BookingPR
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.pageHome = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pageMenu = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pageBooking = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pageHistory = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pageLogin = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.btHome = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btMenu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btDat = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btHistory = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btSign = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.navigationFrame1);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(60, 39);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(1046, 580);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.pageHome);
            this.navigationFrame1.Controls.Add(this.pageMenu);
            this.navigationFrame1.Controls.Add(this.pageBooking);
            this.navigationFrame1.Controls.Add(this.pageHistory);
            this.navigationFrame1.Controls.Add(this.pageLogin);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageHome,
            this.pageMenu,
            this.pageBooking,
            this.pageHistory,
            this.pageLogin});
            this.navigationFrame1.SelectedPage = this.pageMenu;
            this.navigationFrame1.Size = new System.Drawing.Size(1046, 580);
            this.navigationFrame1.TabIndex = 1;
            this.navigationFrame1.Click += new System.EventHandler(this.navigationFrame1_Click);
            // 
            // pageHome
            // 
            this.pageHome.Name = "pageHome";
            this.pageHome.Size = new System.Drawing.Size(1046, 580);
            // 
            // pageMenu
            // 
            this.pageMenu.Name = "pageMenu";
            this.pageMenu.Size = new System.Drawing.Size(1046, 580);
            // 
            // pageBooking
            // 
            this.pageBooking.Name = "pageBooking";
            this.pageBooking.Size = new System.Drawing.Size(1046, 580);
            // 
            // pageHistory
            // 
            this.pageHistory.Name = "pageHistory";
            this.pageHistory.Size = new System.Drawing.Size(1046, 580);
            // 
            // pageLogin
            // 
            this.pageLogin.Name = "pageLogin";
            this.pageLogin.Size = new System.Drawing.Size(1046, 580);
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btHome,
            this.btMenu,
            this.btDat,
            this.btHistory,
            this.btSign});
            this.accordionControl1.Location = new System.Drawing.Point(0, 39);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(60, 580);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // btHome
            // 
            this.btHome.Name = "btHome";
            this.btHome.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btHome.Text = "Trang chủ";
            this.btHome.Click += new System.EventHandler(this.btHome_Click);
            // 
            // btMenu
            // 
            this.btMenu.Name = "btMenu";
            this.btMenu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btMenu.Text = "Menu";
            this.btMenu.Click += new System.EventHandler(this.btMenu_Click);
            // 
            // btDat
            // 
            this.btDat.Name = "btDat";
            this.btDat.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btDat.Text = "Đặt bàn";
            this.btDat.Click += new System.EventHandler(this.btDat_Click);
            // 
            // btHistory
            // 
            this.btHistory.Name = "btHistory";
            this.btHistory.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btHistory.Text = "Lịch sư đặt";
            this.btHistory.Click += new System.EventHandler(this.btHistory_Click);
            // 
            // btSign
            // 
            this.btSign.Name = "btSign";
            this.btSign.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btSign.Text = "Đăng nhập";
            this.btSign.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1106, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 0;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1});
            this.fluentFormDefaultManager1.MaxItemId = 1;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 619);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "Form1";
            this.NavigationControl = this.accordionControl1;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btHome;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btMenu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btDat;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btHistory;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btSign;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        public DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        public DevExpress.XtraBars.Navigation.NavigationPage pageHome;
        private DevExpress.XtraBars.Navigation.NavigationPage pageMenu;
        private DevExpress.XtraBars.Navigation.NavigationPage pageBooking;
        private DevExpress.XtraBars.Navigation.NavigationPage pageHistory;
        private DevExpress.XtraBars.Navigation.NavigationPage pageLogin;
    }
}

