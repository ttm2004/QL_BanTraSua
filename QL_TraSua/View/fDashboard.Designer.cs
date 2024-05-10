
namespace ShopSimple.View
{
    partial class fDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDashboard));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.productItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classifyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tslLogout = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tslImport = new System.Windows.Forms.ToolStripLabel();
            this.tslChangePassword = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslUsername = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tslInvoice = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.tslLogout,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.tslImport,
            this.tslChangePassword,
            this.toolStripSeparator3,
            this.tslUsername,
            this.tslInvoice});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productItem,
            this.classifyItem,
            this.employeeItem,
            this.customerItem,
            this.supplierItem,
            this.statusItem,
            this.invoiceItem,
            this.importItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(85, 23);
            this.toolStripDropDownButton1.Text = "Danh mục";
            // 
            // productItem
            // 
            this.productItem.Name = "productItem";
            this.productItem.Size = new System.Drawing.Size(174, 24);
            this.productItem.Text = "Sản phẩm";
            this.productItem.Click += new System.EventHandler(this.productItem_Click);
            // 
            // classifyItem
            // 
            this.classifyItem.Name = "classifyItem";
            this.classifyItem.Size = new System.Drawing.Size(174, 24);
            this.classifyItem.Text = "Loại sản phẩm";
            this.classifyItem.Click += new System.EventHandler(this.classifyItem_Click);
            // 
            // employeeItem
            // 
            this.employeeItem.Name = "employeeItem";
            this.employeeItem.Size = new System.Drawing.Size(174, 24);
            this.employeeItem.Text = "Nhân viên";
            this.employeeItem.Click += new System.EventHandler(this.employeeItem_Click);
            // 
            // customerItem
            // 
            this.customerItem.Name = "customerItem";
            this.customerItem.Size = new System.Drawing.Size(174, 24);
            this.customerItem.Text = "Khách hàng";
            this.customerItem.Click += new System.EventHandler(this.customerItem_Click);
            // 
            // supplierItem
            // 
            this.supplierItem.Name = "supplierItem";
            this.supplierItem.Size = new System.Drawing.Size(174, 24);
            this.supplierItem.Text = "Nhà cung cấp";
            this.supplierItem.Click += new System.EventHandler(this.supplierItem_Click);
            // 
            // statusItem
            // 
            this.statusItem.Name = "statusItem";
            this.statusItem.Size = new System.Drawing.Size(174, 24);
            this.statusItem.Text = "Tình trạng";
            this.statusItem.Click += new System.EventHandler(this.statusItem_Click);
            // 
            // invoiceItem
            // 
            this.invoiceItem.Name = "invoiceItem";
            this.invoiceItem.Size = new System.Drawing.Size(174, 24);
            this.invoiceItem.Text = "Đơn bán hàng";
            this.invoiceItem.Click += new System.EventHandler(this.invoiceItem_Click);
            // 
            // importItem
            // 
            this.importItem.Name = "importItem";
            this.importItem.Size = new System.Drawing.Size(174, 24);
            this.importItem.Text = "Đơn nhập hàng";
            this.importItem.Click += new System.EventHandler(this.importItem_Click);
            // 
            // tslLogout
            // 
            this.tslLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslLogout.Name = "tslLogout";
            this.tslLogout.Size = new System.Drawing.Size(72, 23);
            this.tslLogout.Text = "Đăng xuất";
            this.tslLogout.Click += new System.EventHandler(this.tslLogout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // tslImport
            // 
            this.tslImport.Name = "tslImport";
            this.tslImport.Size = new System.Drawing.Size(141, 23);
            this.tslImport.Text = "Thêm đơn nhập hàng";
            this.tslImport.Click += new System.EventHandler(this.tslImport_Click);
            // 
            // tslChangePassword
            // 
            this.tslChangePassword.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslChangePassword.Name = "tslChangePassword";
            this.tslChangePassword.Size = new System.Drawing.Size(92, 23);
            this.tslChangePassword.Text = "Đổi mật khẩu";
            this.tslChangePassword.Click += new System.EventHandler(this.tslChangePassword_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // tslUsername
            // 
            this.tslUsername.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslUsername.Name = "tslUsername";
            this.tslUsername.Size = new System.Drawing.Size(69, 23);
            this.tslUsername.Text = "username";
            this.tslUsername.Click += new System.EventHandler(this.tslUsername_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ShopSimple.Properties.Resources.applicationShop;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 424);
            this.panel1.TabIndex = 1;
            // 
            // tslInvoice
            // 
            this.tslInvoice.Name = "tslInvoice";
            this.tslInvoice.Size = new System.Drawing.Size(133, 23);
            this.tslInvoice.Text = "Thêm đơn bán hàng";
            this.tslInvoice.Click += new System.EventHandler(this.tslInvoice_Click);
            // 
            // fDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fDashboard_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem productItem;
        private System.Windows.Forms.ToolStripMenuItem classifyItem;
        private System.Windows.Forms.ToolStripMenuItem employeeItem;
        private System.Windows.Forms.ToolStripMenuItem customerItem;
        private System.Windows.Forms.ToolStripMenuItem supplierItem;
        private System.Windows.Forms.ToolStripMenuItem statusItem;
        private System.Windows.Forms.ToolStripLabel tslLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tslImport;
        private System.Windows.Forms.ToolStripMenuItem invoiceItem;
        private System.Windows.Forms.ToolStripMenuItem importItem;
        private System.Windows.Forms.ToolStripLabel tslChangePassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tslInvoice;
    }
}