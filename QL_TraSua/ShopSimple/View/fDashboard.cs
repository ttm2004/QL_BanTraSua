using ShopSimple.Controller;
using ShopSimple.Library;
using ShopSimple.Model;
using ShopSimple.View.Detail;
using ShopSimple.View.List;
using System;
using System.Windows.Forms;

namespace ShopSimple.View
{
    public partial class fDashboard : Form
    {
        private bool isLogout = false;

        public fDashboard()
        {
            InitializeComponent();
            load();
        }

        private void productItem_Click(object sender, EventArgs e)
        {
            new frmProduct__List().Show();
        }

        private void classifyItem_Click(object sender, EventArgs e)
        {
            new frmCatalog__List().Show();
        }

        private void employeeItem_Click(object sender, EventArgs e)
        {
            new frmAccount__List().Show();
        }

        private void customerItem_Click(object sender, EventArgs e)
        {
            new frmCustomer__List().Show();
        }

        private void supplierItem_Click(object sender, EventArgs e)
        {
            new frmSupplier__List().Show();
        }

        private void statusItem_Click(object sender, EventArgs e)
        {
            new frmStatus__List().Show();
        }

        private void fDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                exit(e);
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void tslLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            isLogout = true;
            this.Close();
        }

        private void tslUsername_Click(object sender, EventArgs e)
        {
            if (Temp.IsAdmin) return;

            using (var frm = new frmAccount__Detail(Temp.User, true))
            {
                frm.ShowDialog();
            }
        }

        private void tslChangePassword_Click(object sender, EventArgs e)
        {
            using (var frm = new frmChangePassword())
            {
                frm.ShowDialog();
            }
        }

        private void tslImport_Click(object sender, EventArgs e)
        {
            using (var frm = new frmImport__Detail(true))
            {
                frm.ShowDialog();
            }
        }

        private void tslInvoice_Click(object sender, EventArgs e)
        {
            using (var frm = new frmInvoice__Detail(true))
            {
                frm.ShowDialog();
            }
        }

        private void importItem_Click(object sender, EventArgs e)
        {
            new frmImport__List().Show();
        }

        private void invoiceItem_Click(object sender, EventArgs e)
        {
            new frmInvoice__List().Show();
        }

        private void load()
        {
            tslImport.Visible = importItem.Visible = Temp.IsAdmin;
            tslInvoice.Visible = !Temp.IsAdmin;
            tslUsername.Text = Temp.IsAdmin ? new bAdmin().GetDetail(Temp.User).Name : new bUser().GetDetail(Temp.User).Name;
        }

        // thực hiện sự kiện đóng form
        private void exit(FormClosingEventArgs e)
        {
            // kiểm tra trạng thái đang xuất khỏi form
            if (isLogout)
            {
                if (ShowMessagebox.Question("Bạn có muốn đăng xuất không?") == DialogResult.Yes)
                {
                    Temp.User = null;
                    Temp.IsAdmin = false;
                    e.Cancel = false;
                }
                else
                {
                    isLogout = false;
                    e.Cancel = true;
                }

                return;
            }

            // nếu không phải là đăng xuất form thì thực hiện đống chương trình
            if (MessageBox.Show("Bạn có muốn thoát ứng dụng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}