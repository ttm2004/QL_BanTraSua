using ShopSimple.Controller;
using ShopSimple.Library;
using ShopSimple.Model;
using System;
using System.Windows.Forms;

namespace ShopSimple.View
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btPrimary_Click(object sender, EventArgs e)
        {
            try
            {
                save();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btDanger_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Lib.ClearControl(pnContent, false);
        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbCurrent.UseSystemPasswordChar = tbNew.UseSystemPasswordChar = tbConfirm.UseSystemPasswordChar = !chbShowPassword.Checked;
        }

        // function
        private void save()
        {
            var pass = tbCurrent.Text.Trim();
            var passNew = tbNew.Text.Trim();
            var passConfirm = tbConfirm.Text.Trim();
            var checkAD = new bAdmin().CheckExists(Temp.User, pass);
            var checkEMP = new bUser().CheckExists(Temp.User, pass);

            if (!Lib.CheckInputNoEmpty(pnContent))
            {
                ShowMessagebox.Error("Không được để trống!");
                return;
            }

            if (!checkAD && !checkEMP)
            {
                ShowMessagebox.Error("Mật khẩu không trùng khớp!");
                return;
            }

            if (!passNew.Equals(passConfirm))
            {
                ShowMessagebox.Error("Mật khẩu mới và nhập lại mật khẩu không trùng khớp!");
                return;
            }

            bool rs = checkAD ? new bAdmin().UpdatePassword(Temp.User, passConfirm) : new bUser().UpdatePassword(Temp.User, passConfirm);

            if (!rs)
            {
                ShowMessagebox.Error("Không thể thay đổi mật khẩu!");
                return;
            }

            this.Close();
        }
    }
}