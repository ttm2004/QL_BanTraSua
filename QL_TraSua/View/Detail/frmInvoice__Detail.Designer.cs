namespace ShopSimple.View.Detail
{
    partial class frmInvoice__Detail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoice__Detail));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btPrimary = new System.Windows.Forms.Button();
            this.btDanger = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnContent = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.pnProd = new System.Windows.Forms.Panel();
            this.btProdFind = new System.Windows.Forms.Button();
            this.btProdClear = new System.Windows.Forms.Button();
            this.btProdDelete = new System.Windows.Forms.Button();
            this.btProdEdit = new System.Windows.Forms.Button();
            this.btProdAddToList = new System.Windows.Forms.Button();
            this.tbProdTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbProdPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbProdAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbProdName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbProdCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbInforInvoice = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btAddNewCustomer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNameCust = new System.Windows.Forms.TextBox();
            this.cbPhone = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNameEmp = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnContent.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.pnProd.SuspendLayout();
            this.gbInforInvoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btPrimary);
            this.panel2.Controls.Add(this.btDanger);
            this.panel2.Controls.Add(this.btRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 580);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1032, 48);
            this.panel2.TabIndex = 5;
            // 
            // btPrimary
            // 
            this.btPrimary.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btPrimary.Location = new System.Drawing.Point(695, 7);
            this.btPrimary.Margin = new System.Windows.Forms.Padding(4);
            this.btPrimary.Name = "btPrimary";
            this.btPrimary.Size = new System.Drawing.Size(105, 35);
            this.btPrimary.TabIndex = 0;
            this.btPrimary.Text = "Thanh toán";
            this.btPrimary.UseVisualStyleBackColor = true;
            this.btPrimary.Click += new System.EventHandler(this.btPrimary_Click);
            // 
            // btDanger
            // 
            this.btDanger.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDanger.Location = new System.Drawing.Point(808, 7);
            this.btDanger.Margin = new System.Windows.Forms.Padding(4);
            this.btDanger.Name = "btDanger";
            this.btDanger.Size = new System.Drawing.Size(105, 35);
            this.btDanger.TabIndex = 0;
            this.btDanger.Text = "Huỷ đơn";
            this.btDanger.UseVisualStyleBackColor = true;
            this.btDanger.Click += new System.EventHandler(this.btDanger_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btRefresh.Location = new System.Drawing.Point(920, 7);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(105, 35);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 32);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(452, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hoá Đơn Bán";
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.groupBox2);
            this.pnContent.Controls.Add(this.groupBox3);
            this.pnContent.Controls.Add(this.gbInforInvoice);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 32);
            this.pnContent.Name = "pnContent";
            this.pnContent.Padding = new System.Windows.Forms.Padding(5);
            this.pnContent.Size = new System.Drawing.Size(1032, 548);
            this.pnContent.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvList);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1022, 233);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phảm nhập";
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
            this.Column4,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.GridColor = System.Drawing.Color.Silver;
            this.dgvList.Location = new System.Drawing.Point(3, 19);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.RowTemplate.Height = 40;
            this.dgvList.RowTemplate.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1016, 181);
            this.dgvList.TabIndex = 3;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvList_CellPainting);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 30.45685F;
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Hình ảnh";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 134.7716F;
            this.Column2.HeaderText = "Mã sản phẩm";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 134.7716F;
            this.Column3.HeaderText = "Tên sản phẩm";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Loại sản phẩm";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "NCC";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Số lượng";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Đơn giá";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Thành tiền";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblQuantity);
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Controls.Add(this.lblCount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1016, 30);
            this.panel3.TabIndex = 2;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQuantity.Location = new System.Drawing.Point(220, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(220, 30);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Tag = "Tổng số lượng:";
            this.lblQuantity.Text = "Tổng số lượng:";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotal.Location = new System.Drawing.Point(796, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(220, 30);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Tag = "Tổng tiền:";
            this.lblTotal.Text = "Tổng tiền:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCount
            // 
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCount.Location = new System.Drawing.Point(0, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(220, 30);
            this.lblCount.TabIndex = 2;
            this.lblCount.Tag = "Số sản phẩm:";
            this.lblCount.Text = "Số sản phẩm:";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.pnProd);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(5, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1022, 178);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin sản phẩm";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.picMain);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 156);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hình ảnh:";
            // 
            // picMain
            // 
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.Image = global::ShopSimple.Properties.Resources.noImages;
            this.picMain.Location = new System.Drawing.Point(3, 19);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(346, 134);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMain.TabIndex = 1;
            this.picMain.TabStop = false;
            // 
            // pnProd
            // 
            this.pnProd.Controls.Add(this.btProdFind);
            this.pnProd.Controls.Add(this.btProdClear);
            this.pnProd.Controls.Add(this.btProdDelete);
            this.pnProd.Controls.Add(this.btProdEdit);
            this.pnProd.Controls.Add(this.btProdAddToList);
            this.pnProd.Controls.Add(this.tbProdTotal);
            this.pnProd.Controls.Add(this.label6);
            this.pnProd.Controls.Add(this.tbProdPrice);
            this.pnProd.Controls.Add(this.label11);
            this.pnProd.Controls.Add(this.tbProdAmount);
            this.pnProd.Controls.Add(this.label10);
            this.pnProd.Controls.Add(this.tbProdName);
            this.pnProd.Controls.Add(this.label8);
            this.pnProd.Controls.Add(this.tbProdCode);
            this.pnProd.Controls.Add(this.label7);
            this.pnProd.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnProd.Location = new System.Drawing.Point(355, 19);
            this.pnProd.Name = "pnProd";
            this.pnProd.Size = new System.Drawing.Size(664, 156);
            this.pnProd.TabIndex = 0;
            // 
            // btProdFind
            // 
            this.btProdFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btProdFind.Location = new System.Drawing.Point(496, 4);
            this.btProdFind.Margin = new System.Windows.Forms.Padding(4);
            this.btProdFind.Name = "btProdFind";
            this.btProdFind.Size = new System.Drawing.Size(164, 35);
            this.btProdFind.TabIndex = 10;
            this.btProdFind.Text = "Tìm sản phẩm";
            this.btProdFind.UseVisualStyleBackColor = true;
            this.btProdFind.Click += new System.EventHandler(this.btProdFind_Click);
            // 
            // btProdClear
            // 
            this.btProdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btProdClear.Location = new System.Drawing.Point(496, 47);
            this.btProdClear.Margin = new System.Windows.Forms.Padding(4);
            this.btProdClear.Name = "btProdClear";
            this.btProdClear.Size = new System.Drawing.Size(164, 35);
            this.btProdClear.TabIndex = 10;
            this.btProdClear.Text = "Làm mới khung nhập";
            this.btProdClear.UseVisualStyleBackColor = true;
            this.btProdClear.Click += new System.EventHandler(this.btProdClear_Click);
            // 
            // btProdDelete
            // 
            this.btProdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btProdDelete.Location = new System.Drawing.Point(328, 47);
            this.btProdDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btProdDelete.Name = "btProdDelete";
            this.btProdDelete.Size = new System.Drawing.Size(164, 35);
            this.btProdDelete.TabIndex = 10;
            this.btProdDelete.Text = "Xoá";
            this.btProdDelete.UseVisualStyleBackColor = true;
            this.btProdDelete.Click += new System.EventHandler(this.btProdDelete_Click);
            // 
            // btProdEdit
            // 
            this.btProdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btProdEdit.Location = new System.Drawing.Point(328, 4);
            this.btProdEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btProdEdit.Name = "btProdEdit";
            this.btProdEdit.Size = new System.Drawing.Size(164, 35);
            this.btProdEdit.TabIndex = 10;
            this.btProdEdit.Text = "Sửa";
            this.btProdEdit.UseVisualStyleBackColor = true;
            this.btProdEdit.Click += new System.EventHandler(this.btProdEdit_Click);
            // 
            // btProdAddToList
            // 
            this.btProdAddToList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btProdAddToList.Location = new System.Drawing.Point(328, 90);
            this.btProdAddToList.Margin = new System.Windows.Forms.Padding(4);
            this.btProdAddToList.Name = "btProdAddToList";
            this.btProdAddToList.Size = new System.Drawing.Size(164, 35);
            this.btProdAddToList.TabIndex = 10;
            this.btProdAddToList.Text = "Thêm vào danh sách";
            this.btProdAddToList.UseVisualStyleBackColor = true;
            this.btProdAddToList.Click += new System.EventHandler(this.btProdAddToList_Click);
            // 
            // tbProdTotal
            // 
            this.tbProdTotal.Location = new System.Drawing.Point(93, 125);
            this.tbProdTotal.Name = "tbProdTotal";
            this.tbProdTotal.ReadOnly = true;
            this.tbProdTotal.Size = new System.Drawing.Size(225, 23);
            this.tbProdTotal.TabIndex = 3;
            this.tbProdTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Thành tiền:";
            // 
            // tbProdPrice
            // 
            this.tbProdPrice.Location = new System.Drawing.Point(93, 96);
            this.tbProdPrice.Name = "tbProdPrice";
            this.tbProdPrice.ReadOnly = true;
            this.tbProdPrice.Size = new System.Drawing.Size(225, 23);
            this.tbProdPrice.TabIndex = 3;
            this.tbProdPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Đơn giá:";
            // 
            // tbProdAmount
            // 
            this.tbProdAmount.Location = new System.Drawing.Point(93, 67);
            this.tbProdAmount.Name = "tbProdAmount";
            this.tbProdAmount.Size = new System.Drawing.Size(225, 23);
            this.tbProdAmount.TabIndex = 3;
            this.tbProdAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbProdAmount.TextChanged += new System.EventHandler(this.tbProdAmount_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Số lượng:";
            // 
            // tbProdName
            // 
            this.tbProdName.Location = new System.Drawing.Point(93, 38);
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.ReadOnly = true;
            this.tbProdName.Size = new System.Drawing.Size(225, 23);
            this.tbProdName.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tên SP:";
            // 
            // tbProdCode
            // 
            this.tbProdCode.Location = new System.Drawing.Point(93, 9);
            this.tbProdCode.Name = "tbProdCode";
            this.tbProdCode.ReadOnly = true;
            this.tbProdCode.Size = new System.Drawing.Size(225, 23);
            this.tbProdCode.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Mã SP:";
            // 
            // gbInforInvoice
            // 
            this.gbInforInvoice.Controls.Add(this.label16);
            this.gbInforInvoice.Controls.Add(this.label15);
            this.gbInforInvoice.Controls.Add(this.label5);
            this.gbInforInvoice.Controls.Add(this.label4);
            this.gbInforInvoice.Controls.Add(this.btAddNewCustomer);
            this.gbInforInvoice.Controls.Add(this.label3);
            this.gbInforInvoice.Controls.Add(this.tbNameCust);
            this.gbInforInvoice.Controls.Add(this.cbPhone);
            this.gbInforInvoice.Controls.Add(this.label2);
            this.gbInforInvoice.Controls.Add(this.tbNameEmp);
            this.gbInforInvoice.Controls.Add(this.tbUser);
            this.gbInforInvoice.Controls.Add(this.tbDate);
            this.gbInforInvoice.Controls.Add(this.tbCode);
            this.gbInforInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInforInvoice.Location = new System.Drawing.Point(5, 5);
            this.gbInforInvoice.Name = "gbInforInvoice";
            this.gbInforInvoice.Size = new System.Drawing.Size(1022, 127);
            this.gbInforInvoice.TabIndex = 7;
            this.gbInforInvoice.TabStop = false;
            this.gbInforInvoice.Tag = "Thông tin hoá đơn";
            this.gbInforInvoice.Text = "Thông tin hoá đơn";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(669, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 17);
            this.label16.TabIndex = 2;
            this.label16.Text = "Tên khách hàng:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(681, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 17);
            this.label15.TabIndex = 2;
            this.label15.Text = "Số điện thoại:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tên người bán:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tài khoản:";
            // 
            // btAddNewCustomer
            // 
            this.btAddNewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddNewCustomer.Location = new System.Drawing.Point(854, 87);
            this.btAddNewCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btAddNewCustomer.Name = "btAddNewCustomer";
            this.btAddNewCustomer.Size = new System.Drawing.Size(164, 35);
            this.btAddNewCustomer.TabIndex = 10;
            this.btAddNewCustomer.Text = "Thêm khách hàng";
            this.btAddNewCustomer.UseVisualStyleBackColor = true;
            this.btAddNewCustomer.Click += new System.EventHandler(this.btAddNewCustomer_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày bán:";
            // 
            // tbNameCust
            // 
            this.tbNameCust.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbNameCust.Location = new System.Drawing.Point(788, 57);
            this.tbNameCust.Name = "tbNameCust";
            this.tbNameCust.ReadOnly = true;
            this.tbNameCust.Size = new System.Drawing.Size(204, 23);
            this.tbNameCust.TabIndex = 3;
            // 
            // cbPhone
            // 
            this.cbPhone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPhone.FormattingEnabled = true;
            this.cbPhone.ItemHeight = 16;
            this.cbPhone.Location = new System.Drawing.Point(788, 21);
            this.cbPhone.Name = "cbPhone";
            this.cbPhone.Size = new System.Drawing.Size(204, 24);
            this.cbPhone.TabIndex = 9;
            this.cbPhone.SelectedIndexChanged += new System.EventHandler(this.cbPhone_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hoá đơn:";
            // 
            // tbNameEmp
            // 
            this.tbNameEmp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbNameEmp.Location = new System.Drawing.Point(439, 57);
            this.tbNameEmp.Name = "tbNameEmp";
            this.tbNameEmp.ReadOnly = true;
            this.tbNameEmp.Size = new System.Drawing.Size(204, 23);
            this.tbNameEmp.TabIndex = 3;
            // 
            // tbUser
            // 
            this.tbUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbUser.Location = new System.Drawing.Point(439, 22);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(204, 23);
            this.tbUser.TabIndex = 3;
            // 
            // tbDate
            // 
            this.tbDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbDate.Location = new System.Drawing.Point(106, 57);
            this.tbDate.Name = "tbDate";
            this.tbDate.ReadOnly = true;
            this.tbDate.Size = new System.Drawing.Size(204, 23);
            this.tbDate.TabIndex = 3;
            this.tbDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCode
            // 
            this.tbCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbCode.Location = new System.Drawing.Point(106, 22);
            this.tbCode.Name = "tbCode";
            this.tbCode.ReadOnly = true;
            this.tbCode.Size = new System.Drawing.Size(204, 23);
            this.tbCode.TabIndex = 3;
            // 
            // frmInvoice__Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 628);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInvoice__Detail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoá Đơn Bán";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInvoice__Detail_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnContent.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.pnProd.ResumeLayout(false);
            this.pnProd.PerformLayout();
            this.gbInforInvoice.ResumeLayout(false);
            this.gbInforInvoice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btPrimary;
        private System.Windows.Forms.Button btDanger;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Panel pnProd;
        private System.Windows.Forms.Button btProdFind;
        private System.Windows.Forms.Button btProdClear;
        private System.Windows.Forms.Button btProdDelete;
        private System.Windows.Forms.Button btProdEdit;
        private System.Windows.Forms.Button btProdAddToList;
        private System.Windows.Forms.TextBox tbProdPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbProdAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbProdName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbProdCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbInforInvoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNameEmp;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbNameCust;
        private System.Windows.Forms.TextBox tbProdTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btAddNewCustomer;
        private System.Windows.Forms.ComboBox cbPhone;
    }
}