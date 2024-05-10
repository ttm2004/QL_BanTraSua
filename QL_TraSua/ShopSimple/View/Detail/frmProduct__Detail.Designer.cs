namespace ShopSimple.View.Detail
{
    partial class frmProduct__Detail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct__Detail));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btPrimary = new System.Windows.Forms.Button();
            this.btDanger = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.pnContent = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btUpdateOrView = new System.Windows.Forms.Button();
            this.cbImages = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.cbCatalog = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tbImages = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnContent.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 44);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(346, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sản Phẩm";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btPrimary);
            this.panel2.Controls.Add(this.btDanger);
            this.panel2.Controls.Add(this.btRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 499);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 50);
            this.panel2.TabIndex = 0;
            // 
            // btPrimary
            // 
            this.btPrimary.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btPrimary.Location = new System.Drawing.Point(512, 5);
            this.btPrimary.Name = "btPrimary";
            this.btPrimary.Size = new System.Drawing.Size(87, 40);
            this.btPrimary.TabIndex = 0;
            this.btPrimary.Text = "Lưu";
            this.btPrimary.UseVisualStyleBackColor = true;
            this.btPrimary.Click += new System.EventHandler(this.btPrimary_Click);
            // 
            // btDanger
            // 
            this.btDanger.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDanger.Location = new System.Drawing.Point(607, 5);
            this.btDanger.Name = "btDanger";
            this.btDanger.Size = new System.Drawing.Size(87, 40);
            this.btDanger.TabIndex = 0;
            this.btDanger.Text = "Huỷ";
            this.btDanger.UseVisualStyleBackColor = true;
            this.btDanger.Click += new System.EventHandler(this.btDanger_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btRefresh.Location = new System.Drawing.Point(702, 5);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(87, 40);
            this.btRefresh.TabIndex = 0;
            this.btRefresh.Text = "Làm mới";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.groupBox2);
            this.pnContent.Controls.Add(this.gbContent);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 44);
            this.pnContent.Name = "pnContent";
            this.pnContent.Padding = new System.Windows.Forms.Padding(6, 2, 6, 4);
            this.pnContent.Size = new System.Drawing.Size(796, 455);
            this.pnContent.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(6, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 449);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hình ảnh";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picMain);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 349);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // picMain
            // 
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.Image = global::ShopSimple.Properties.Resources.noImages;
            this.picMain.Location = new System.Drawing.Point(3, 19);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(482, 327);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMain.TabIndex = 0;
            this.picMain.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btUpdateOrView);
            this.groupBox1.Controls.Add(this.cbImages);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 368);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btUpdateOrView
            // 
            this.btUpdateOrView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdateOrView.Location = new System.Drawing.Point(345, 41);
            this.btUpdateOrView.Name = "btUpdateOrView";
            this.btUpdateOrView.Size = new System.Drawing.Size(140, 33);
            this.btUpdateOrView.TabIndex = 0;
            this.btUpdateOrView.Text = "Xem";
            this.btUpdateOrView.UseVisualStyleBackColor = true;
            this.btUpdateOrView.Click += new System.EventHandler(this.btUpdateOrView_Click);
            // 
            // cbImages
            // 
            this.cbImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImages.FormattingEnabled = true;
            this.cbImages.Location = new System.Drawing.Point(162, 12);
            this.cbImages.Name = "cbImages";
            this.cbImages.Size = new System.Drawing.Size(323, 24);
            this.cbImages.TabIndex = 2;
            this.cbImages.SelectedIndexChanged += new System.EventHandler(this.cbImages_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hiển thị hình ảnh:";
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.cbStatus);
            this.gbContent.Controls.Add(this.cbSupplier);
            this.gbContent.Controls.Add(this.cbCatalog);
            this.gbContent.Controls.Add(this.label2);
            this.gbContent.Controls.Add(this.tbCode);
            this.gbContent.Controls.Add(this.tbImages);
            this.gbContent.Controls.Add(this.label6);
            this.gbContent.Controls.Add(this.tbAmount);
            this.gbContent.Controls.Add(this.label10);
            this.gbContent.Controls.Add(this.label8);
            this.gbContent.Controls.Add(this.tbPrice);
            this.gbContent.Controls.Add(this.label9);
            this.gbContent.Controls.Add(this.label7);
            this.gbContent.Controls.Add(this.label5);
            this.gbContent.Controls.Add(this.tbName);
            this.gbContent.Controls.Add(this.label3);
            this.gbContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbContent.Location = new System.Drawing.Point(500, 2);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(290, 449);
            this.gbContent.TabIndex = 2;
            this.gbContent.TabStop = false;
            this.gbContent.Text = "Thông tin";
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.ItemHeight = 16;
            this.cbStatus.Location = new System.Drawing.Point(29, 418);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(233, 24);
            this.cbStatus.TabIndex = 2;
            // 
            // cbSupplier
            // 
            this.cbSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.ItemHeight = 16;
            this.cbSupplier.Location = new System.Drawing.Point(29, 262);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(233, 24);
            this.cbSupplier.TabIndex = 2;
            // 
            // cbCatalog
            // 
            this.cbCatalog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbCatalog.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCatalog.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCatalog.FormattingEnabled = true;
            this.cbCatalog.ItemHeight = 16;
            this.cbCatalog.Location = new System.Drawing.Point(29, 208);
            this.cbCatalog.Name = "cbCatalog";
            this.cbCatalog.Size = new System.Drawing.Size(233, 24);
            this.cbCatalog.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã sản phẩm:";
            // 
            // tbCode
            // 
            this.tbCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbCode.Location = new System.Drawing.Point(29, 52);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(233, 23);
            this.tbCode.TabIndex = 1;
            // 
            // tbImages
            // 
            this.tbImages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbImages.Location = new System.Drawing.Point(29, 156);
            this.tbImages.Name = "tbImages";
            this.tbImages.ReadOnly = true;
            this.tbImages.Size = new System.Drawing.Size(233, 23);
            this.tbImages.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Hình ảnh:";
            // 
            // tbAmount
            // 
            this.tbAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbAmount.Location = new System.Drawing.Point(29, 312);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(233, 23);
            this.tbAmount.TabIndex = 1;
            this.tbAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 393);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Trạng thái:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Số lượng:";
            // 
            // tbPrice
            // 
            this.tbPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPrice.Location = new System.Drawing.Point(29, 364);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(233, 23);
            this.tbPrice.TabIndex = 1;
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 341);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Đơn giá:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nhà cung cấp:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Loại sản phẩm:";
            // 
            // tbName
            // 
            this.tbName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbName.Location = new System.Drawing.Point(29, 104);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(233, 23);
            this.tbName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên sản phẩm:";
            // 
            // frmProduct__Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(796, 549);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "frmProduct__Detail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sản Phẩm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduct_Detail_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnContent.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbContent.ResumeLayout(false);
            this.gbContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPrimary;
        private System.Windows.Forms.Button btDanger;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.ComboBox cbImages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btUpdateOrView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbImages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbCatalog;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbSupplier;
    }
}