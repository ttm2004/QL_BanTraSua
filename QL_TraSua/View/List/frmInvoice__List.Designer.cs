namespace ShopSimple.View.List
{
    partial class frmInvoice__List
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoice__List));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btView = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnContent = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.chbDate = new System.Windows.Forms.CheckBox();
            this.chbPrice = new System.Windows.Forms.CheckBox();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.btClear = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbPriceTo = new System.Windows.Forms.TextBox();
            this.tbPriceFrom = new System.Windows.Forms.TextBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnContent.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btView);
            this.panel2.Controls.Add(this.btAdd);
            this.panel2.Controls.Add(this.btDelete);
            this.panel2.Controls.Add(this.btRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 427);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 59);
            this.panel2.TabIndex = 3;
            // 
            // btView
            // 
            this.btView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btView.Location = new System.Drawing.Point(476, 9);
            this.btView.Margin = new System.Windows.Forms.Padding(5);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(140, 43);
            this.btView.TabIndex = 0;
            this.btView.Text = "Xem";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btAdd.Location = new System.Drawing.Point(176, 9);
            this.btAdd.Margin = new System.Windows.Forms.Padding(5);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(140, 43);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "Thêm";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDelete.Location = new System.Drawing.Point(326, 9);
            this.btDelete.Margin = new System.Windows.Forms.Padding(5);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(140, 43);
            this.btDelete.TabIndex = 0;
            this.btDelete.Text = "Xoá";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btRefresh.Location = new System.Drawing.Point(625, 9);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(140, 43);
            this.btRefresh.TabIndex = 0;
            this.btRefresh.Text = "Làm mới";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 39);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Bán Hàng";
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.groupBox2);
            this.pnContent.Controls.Add(this.gbSearch);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 39);
            this.pnContent.Margin = new System.Windows.Forms.Padding(5);
            this.pnContent.Name = "pnContent";
            this.pnContent.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.pnContent.Size = new System.Drawing.Size(774, 388);
            this.pnContent.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(9, 164);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(756, 217);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column9,
            this.Column6,
            this.Column7});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.GridColor = System.Drawing.Color.Silver;
            this.dgvList.Location = new System.Drawing.Point(5, 21);
            this.dgvList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.RowTemplate.Height = 40;
            this.dgvList.RowTemplate.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(746, 191);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            this.dgvList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvList_CellPainting);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 15.50994F;
            this.Column1.HeaderText = "STT";
            this.Column1.MinimumWidth = 50;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 40.74545F;
            this.Column2.HeaderText = "Mã đơn bán";
            this.Column2.MinimumWidth = 170;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 170;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 49.99167F;
            this.Column3.HeaderText = "Ngày bán";
            this.Column3.MinimumWidth = 200;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 37.09363F;
            this.Column4.HeaderText = "Tài khoản";
            this.Column4.MinimumWidth = 120;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 37.09363F;
            this.Column5.HeaderText = "Tên người bán";
            this.Column5.MinimumWidth = 120;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 191.8782F;
            this.Column8.HeaderText = "SDT";
            this.Column8.MinimumWidth = 120;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 120;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 453.5003F;
            this.Column9.HeaderText = "Tên khách hàng";
            this.Column9.MinimumWidth = 120;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 120;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 37.09363F;
            this.Column6.HeaderText = "Số lượng";
            this.Column6.MinimumWidth = 120;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 120;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 37.09363F;
            this.Column7.HeaderText = "Tổng tiền";
            this.Column7.MinimumWidth = 120;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 120;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.chbDate);
            this.gbSearch.Controls.Add(this.chbPrice);
            this.gbSearch.Controls.Add(this.dpTo);
            this.gbSearch.Controls.Add(this.dpFrom);
            this.gbSearch.Controls.Add(this.btClear);
            this.gbSearch.Controls.Add(this.btSearch);
            this.gbSearch.Controls.Add(this.tbPriceTo);
            this.gbSearch.Controls.Add(this.tbPriceFrom);
            this.gbSearch.Controls.Add(this.tbSearch);
            this.gbSearch.Controls.Add(this.label6);
            this.gbSearch.Controls.Add(this.label4);
            this.gbSearch.Controls.Add(this.lblResult);
            this.gbSearch.Controls.Add(this.label5);
            this.gbSearch.Controls.Add(this.label3);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(9, 7);
            this.gbSearch.Margin = new System.Windows.Forms.Padding(5);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Padding = new System.Windows.Forms.Padding(5);
            this.gbSearch.Size = new System.Drawing.Size(756, 157);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Tìm kiếm";
            // 
            // chbDate
            // 
            this.chbDate.AutoSize = true;
            this.chbDate.Location = new System.Drawing.Point(442, 97);
            this.chbDate.Name = "chbDate";
            this.chbDate.Size = new System.Drawing.Size(118, 21);
            this.chbDate.TabIndex = 3;
            this.chbDate.Text = "Tìm kiếm ngày";
            this.chbDate.UseVisualStyleBackColor = true;
            this.chbDate.CheckedChanged += new System.EventHandler(this.chbDate_CheckedChanged);
            // 
            // chbPrice
            // 
            this.chbPrice.AutoSize = true;
            this.chbPrice.Location = new System.Drawing.Point(442, 61);
            this.chbPrice.Name = "chbPrice";
            this.chbPrice.Size = new System.Drawing.Size(106, 21);
            this.chbPrice.TabIndex = 3;
            this.chbPrice.Text = "Tìm kiếm giá";
            this.chbPrice.UseVisualStyleBackColor = true;
            this.chbPrice.CheckedChanged += new System.EventHandler(this.chbPrice_CheckedChanged);
            // 
            // dpTo
            // 
            this.dpTo.CustomFormat = "dd/MM/yyyy";
            this.dpTo.Enabled = false;
            this.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpTo.Location = new System.Drawing.Point(85, 96);
            this.dpTo.Margin = new System.Windows.Forms.Padding(4);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(121, 23);
            this.dpTo.TabIndex = 2;
            // 
            // dpFrom
            // 
            this.dpFrom.CustomFormat = "dd/MM/yyyy";
            this.dpFrom.Enabled = false;
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFrom.Location = new System.Drawing.Point(85, 60);
            this.dpFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(121, 23);
            this.dpFrom.TabIndex = 2;
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.Location = new System.Drawing.Point(629, 61);
            this.btClear.Margin = new System.Windows.Forms.Padding(5);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(121, 38);
            this.btClear.TabIndex = 0;
            this.btClear.Text = "Xoá";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btSearch
            // 
            this.btSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSearch.Location = new System.Drawing.Point(629, 109);
            this.btSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(121, 38);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "Tìm";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbPriceTo
            // 
            this.tbPriceTo.Enabled = false;
            this.tbPriceTo.Location = new System.Drawing.Point(285, 96);
            this.tbPriceTo.Margin = new System.Windows.Forms.Padding(4);
            this.tbPriceTo.Name = "tbPriceTo";
            this.tbPriceTo.Size = new System.Drawing.Size(150, 23);
            this.tbPriceTo.TabIndex = 1;
            // 
            // tbPriceFrom
            // 
            this.tbPriceFrom.Enabled = false;
            this.tbPriceFrom.Location = new System.Drawing.Point(285, 60);
            this.tbPriceFrom.Margin = new System.Windows.Forms.Padding(4);
            this.tbPriceFrom.Name = "tbPriceFrom";
            this.tbPriceFrom.Size = new System.Drawing.Size(150, 23);
            this.tbPriceFrom.TabIndex = 1;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(85, 24);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(445, 23);
            this.tbSearch.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Đến giá:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 99);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đến ngày:";
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(8, 133);
            this.lblResult.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(110, 17);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Kêt quả tìm thấy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Giá từ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tìm kiếm:";
            // 
            // frmInvoice__List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(774, 486);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInvoice__List";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Bán Hàng";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnContent.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPriceTo;
        private System.Windows.Forms.TextBox tbPriceFrom;
        private System.Windows.Forms.CheckBox chbDate;
        private System.Windows.Forms.CheckBox chbPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}