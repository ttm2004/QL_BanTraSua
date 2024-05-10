namespace ShopSimple.View
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btPrimary = new System.Windows.Forms.Button();
            this.btDanger = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.pnContent = new System.Windows.Forms.Panel();
            this.chbShowPassword = new System.Windows.Forms.CheckBox();
            this.tbConfirm = new System.Windows.Forms.TextBox();
            this.tbNew = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCurrent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 44);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đổi mật khẩu";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btPrimary);
            this.panel2.Controls.Add(this.btDanger);
            this.panel2.Controls.Add(this.btRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 277);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 50);
            this.panel2.TabIndex = 0;
            // 
            // btPrimary
            // 
            this.btPrimary.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btPrimary.Location = new System.Drawing.Point(8, 5);
            this.btPrimary.Name = "btPrimary";
            this.btPrimary.Size = new System.Drawing.Size(87, 40);
            this.btPrimary.TabIndex = 4;
            this.btPrimary.Text = "Lưu";
            this.btPrimary.UseVisualStyleBackColor = true;
            this.btPrimary.Click += new System.EventHandler(this.btPrimary_Click);
            // 
            // btDanger
            // 
            this.btDanger.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDanger.Location = new System.Drawing.Point(103, 5);
            this.btDanger.Name = "btDanger";
            this.btDanger.Size = new System.Drawing.Size(87, 40);
            this.btDanger.TabIndex = 5;
            this.btDanger.Text = "Huỷ";
            this.btDanger.UseVisualStyleBackColor = true;
            this.btDanger.Click += new System.EventHandler(this.btDanger_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btRefresh.Location = new System.Drawing.Point(198, 5);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(87, 40);
            this.btRefresh.TabIndex = 6;
            this.btRefresh.Text = "Làm mới";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.chbShowPassword);
            this.pnContent.Controls.Add(this.tbConfirm);
            this.pnContent.Controls.Add(this.tbNew);
            this.pnContent.Controls.Add(this.label4);
            this.pnContent.Controls.Add(this.label3);
            this.pnContent.Controls.Add(this.tbCurrent);
            this.pnContent.Controls.Add(this.label2);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 44);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(292, 233);
            this.pnContent.TabIndex = 0;
            // 
            // chbShowPassword
            // 
            this.chbShowPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbShowPassword.AutoSize = true;
            this.chbShowPassword.Location = new System.Drawing.Point(30, 201);
            this.chbShowPassword.Name = "chbShowPassword";
            this.chbShowPassword.Size = new System.Drawing.Size(137, 21);
            this.chbShowPassword.TabIndex = 3;
            this.chbShowPassword.Text = "Hiển thị mật khẩu";
            this.chbShowPassword.UseVisualStyleBackColor = true;
            this.chbShowPassword.CheckedChanged += new System.EventHandler(this.chbShowPassword_CheckedChanged);
            // 
            // tbConfirm
            // 
            this.tbConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbConfirm.Location = new System.Drawing.Point(30, 162);
            this.tbConfirm.Name = "tbConfirm";
            this.tbConfirm.Size = new System.Drawing.Size(233, 23);
            this.tbConfirm.TabIndex = 2;
            this.tbConfirm.UseSystemPasswordChar = true;
            // 
            // tbNew
            // 
            this.tbNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbNew.Location = new System.Drawing.Point(30, 100);
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(233, 23);
            this.tbNew.TabIndex = 1;
            this.tbNew.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nhập lại mật khẩu mới:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu mới:";
            // 
            // tbCurrent
            // 
            this.tbCurrent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbCurrent.Location = new System.Drawing.Point(30, 38);
            this.tbCurrent.Name = "tbCurrent";
            this.tbCurrent.Size = new System.Drawing.Size(233, 23);
            this.tbCurrent.TabIndex = 0;
            this.tbCurrent.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu hiện tại:";
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(292, 327);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnContent.ResumeLayout(false);
            this.pnContent.PerformLayout();
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
        private System.Windows.Forms.TextBox tbCurrent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbConfirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbShowPassword;
    }
}