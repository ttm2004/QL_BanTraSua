using ShopSimple.Controller;
using ShopSimple.Library;
using ShopSimple.Model;
using System;
using System.Windows.Forms;

namespace ShopSimple.View.Detail
{
    public partial class frmCustomer__Detail : Form
    {
        public SendNewCustomer send; // truyền dữ liệu giữa hai form
        private bool isAdd, isViewOrEdit;
        private bool fixAutoClose = false; // sửa lỗi tự động đống form khi mở mở dưới dạng dialog
        private bool isSendPhone = false;
        private Customer customer;

        public frmCustomer__Detail(bool IsAdd)
        {
            InitializeComponent();
            this.isAdd = IsAdd;
            this.isViewOrEdit = true;
            load();
        }

        public frmCustomer__Detail(bool IsAdd, SendNewCustomer sender)
        {
            InitializeComponent();
            this.isAdd = IsAdd;
            this.isViewOrEdit = true;
            this.send = sender;
            this.isSendPhone = true;
            load();
        }

        public frmCustomer__Detail(string Code, bool IsViewOrEdit)
        {
            InitializeComponent();
            this.isViewOrEdit = IsViewOrEdit;
            this.isAdd = false;
            load(Code);
        }

        private void btPrimary_Click(object sender, EventArgs e)
        {
            try
            {
                eventPrimary();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btDanger_Click(object sender, EventArgs e)
        {
            try
            {
                eventDanger();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                eventRefresh();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void frmCustomer_Detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Lib.CheckInputNoEmpty(pnContent) || (!isAdd && isViewOrEdit))
            {
                e.Cancel = fixAutoClose;
                fixAutoClose = !fixAutoClose;
                return;
            }

            if (ShowMessagebox.Question($"Bạn có muốn thoát {this.Text} không?") == DialogResult.Yes)
            {
                e.Cancel = fixAutoClose;
                fixAutoClose = !fixAutoClose;
            }
            else
            {
                e.Cancel = true;
            }
        }

        // function
        private void load()
        {
            tbCode.Select();
            CURD__Button();
        }

        private void load(string code)
        {
            btPrimary.Select();
            CURD__Control__EnableDisable();
            CURD__Button();
            binding(code);
        }

        // hiển thị dữ liệu lên các textbox
        private void binding(string code)
        {
            customer = new bCustomer().GetDetail(code);
            tbCode.Text = customer.Phone;
            tbName.Text = customer.Name;
        }

        // hàm xử lý sự kiện cho nút primary
        private void eventPrimary()
        {
            if (!isViewOrEdit || isAdd)
            {
                if (inputValidate())
                    save();
            }
            else if (isViewOrEdit)
            {
                isViewOrEdit = false;
                CURD__Control__EnableDisable();
                CURD__Button();
            }
        }

        // hàm xử lý sự kiện cho nút danger
        private void eventDanger()
        {
            if (isAdd || isViewOrEdit)
            {
                cancelOrDelete();
            }
            else
            {
                isViewOrEdit = true;
                fixAutoClose = false;
                CURD__Control__EnableDisable();
                CURD__Button();
                binding(customer.Phone);
            }
        }

        // hàm xử lý sự kiện cho nút refresh
        private void eventRefresh()
        {
            if (isAdd)
            {
                Lib.ClearControl(pnContent, true);
            }
            else if (!isViewOrEdit)
            {
                binding(customer.Phone);
            }
        }

        // Hiển thị lại tên trên các button
        private void CURD__Button()
        {
            Lib.ChangeTextButtonCURD(isAdd, isViewOrEdit, btPrimary, btDanger);
        }

        // chuyển đội trạng thái tự động. Cho phép nhập liệu vào các Textbox
        private void CURD__Control__EnableDisable()
        {
            Lib.ReadOnlyControl(pnContent, isViewOrEdit);
            tbCode.ReadOnly = !isAdd;
        }

        // kiểm tra các textbox không trống trước khi lưu vào db
        private bool inputValidate()
        {
            bool check = Lib.CheckInputNoEmpty(pnContent);

            if (!check)
            {
                ShowMessagebox.Error("Không có dữ liệu đầu vào!");
                return false;
            }

            return check;
        }

        // hàm đóng gói dữ liệu (gán các giá trị vào đối tượng tương ứng)
        private void package()
        {
            this.customer = new Customer
            {
                Phone = tbCode.Text.Trim(),
                Name = tbName.Text.Trim()
            };
        }

        private void cancelOrDelete()
        {
            if (isViewOrEdit && !isAdd)
            {
                string text = $"Bạn có muốn xoá {this.Text}: {tbCode.Text} - {tbName.Text} không?";

                if (ShowMessagebox.Question(text) == DialogResult.Yes)
                {
                    delete();
                }
            }
            else
            {
                this.Close();
            }
        }

        // Xử lý lưu dữ liệu vào db
        private void save()
        {
            package();
            bCustomer b = new bCustomer();
            string mess = $"{customer.Phone}: {customer.Name}";

            if (b.CheckExists(customer.Phone) && isAdd)
            {
                var d = b.GetDetail(customer.Phone);
                mess = $"Đã tồn tại {customer.Phone}\n{d.Phone}: {d.Name}";
                ShowMessagebox.Error(mess);
                return;
            }

            bool result = isAdd ? b.Add(customer) : b.Update(customer);

            if (!result)
            {
                ShowMessagebox.Error($"Không thể lưu {mess}!");
                return;
            }

            this.DialogResult = DialogResult.Yes;
            ShowMessagebox.Susscess($"Thêm {mess} thành công.");

            if (isAdd)
            {
                this.Close();

                if (isSendPhone)
                    this.send(customer.Phone);

                return;
            }

            isViewOrEdit = true;
            CURD__Control__EnableDisable();
            CURD__Button();
        }

        // Xử lý xoá sdữ liệu trong db
        private void delete()
        {
            package();
            bCustomer b = new bCustomer();
            string mess = $"{customer.Phone} - {customer.Name}";

            if (!b.CheckExists(customer.Phone))
            {
                ShowMessagebox.Error($"Đã tồn tại {mess}!");
                return;
            }

            bool result = b.Delete(customer.Phone);

            if (!result)
            {
                ShowMessagebox.Error($"Không thể xoá {mess}!");
                return;
            }

            ShowMessagebox.Susscess($"Xoá {mess} thành công.");
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}