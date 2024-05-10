using ShopSimple.Controller;
using ShopSimple.Library;
using ShopSimple.Model;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShopSimple.View.Detail
{
    public partial class frmProduct__Detail : Form
    {
        private bool isAdd, isViewOrEdit;
        private bool fixAutoClose = false; // sửa lỗi tự động đống form khi mở mở dưới dạng dialog
        private Product product;
        private string pathImage;
        private DateTime date;
        private bool isChangeImage = false;

        public frmProduct__Detail(string Code, bool IsViewOrEdit)
        {
            InitializeComponent();
            this.isViewOrEdit = IsViewOrEdit;
            this.isAdd = false;
            load(Code);
        }

        private void cbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (isChangeImage)
                {
                    Lib.ImageLoad(cbImages.SelectedItem.ToString(), pathImage, picMain);
                    return;
                }

                Lib.ImageLoad(cbImages.SelectedItem.ToString(), picMain);
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btUpdateOrView_Click(object sender, EventArgs e)
        {
            try
            {
                if (isViewOrEdit)
                {
                    using (var frm = new frmViewImage(Lib.GetImage(cbImages.SelectedItem.ToString())))
                    {
                        frm.ShowDialog();
                    }
                }
                else
                {
                    openDialog();
                }
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
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

        private void frmProduct_Detail_FormClosing(object sender, FormClosingEventArgs e)
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
        private void load(string code)
        {
            btPrimary.Select();
            CURD__Control__EnableDisable();
            CURD__Button();
            loadCombobox();
            binding(code);
            eventRole();
        }

        // kiểm tra phân quyền để hiển thị chức năng đúng với phân quyền người dùng.
        private void eventRole()
        {
            btPrimary.Visible = btDanger.Visible = Temp.IsAdmin;
        }

        // hiển thị dữ liệu lên các textbox
        private void binding(string code)
        {
            product = new bProduct().GetDetail(code);
            tbCode.Text = product.ProductCode;
            tbName.Text = product.Name;
            tbImages.Text = product.Image;
            tbAmount.Text = product.Amount.ToString();
            tbPrice.Text = Lib.ConvertPrice(product.Price.ToString(), true);
            cbCatalog.SelectedValue = product.CatalogID;
            cbSupplier.SelectedValue = product.SupplierID;
            cbStatus.SelectedValue = product.StatusID;
            date = product.CreateDate;
            loadComboxboImage(product.Image.Split(','));
        }

        private void loadCombobox()
        {
            cbCatalog.DataSource = new bCatalog().Select();
            cbStatus.DataSource = new bStatus().Select();
            cbSupplier.DataSource = new bSupplier().Select();

            cbCatalog.DisplayMember = cbStatus.DisplayMember = cbSupplier.DisplayMember = "Display";
            cbCatalog.ValueMember = cbStatus.ValueMember = cbSupplier.ValueMember = "Value";
        }

        private void loadComboxboImage(string[] imgs)
        {
            cbImages.Items.Clear();
            cbImages.Items.AddRange(imgs.Select(i => i.Trim()).ToArray());
            cbImages.SelectedIndex = 0;
        }

        // hàm xử lý sự kiện cho nút primary
        private void eventPrimary()
        {
            if (!isViewOrEdit)
            {
                if (inputValidate())
                    save();
            }
            else
            {
                isViewOrEdit = false;
                btDanger.Enabled = true;
                CURD__Control__EnableDisable();
                CURD__Button();
            }
        }

        // hàm xử lý sự kiện cho nút danger
        private void eventDanger()
        {
            isViewOrEdit = true;
            fixAutoClose = false;
            isChangeImage = false;
            btDanger.Enabled = false;
            CURD__Control__EnableDisable();
            CURD__Button();
            binding(product.ProductCode);
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
                binding(product.ProductCode);
            }
        }

        // Hiển thị lại tên trên các button
        private void CURD__Button()
        {
            Lib.ChangeTextButtonCURD(isAdd, isViewOrEdit, btPrimary, btDanger);
            btUpdateOrView.Text = isViewOrEdit ? "Xem ảnh" : "Cập nhật";
        }

        // chuyển đội trạng thái tự động. Cho phép nhập liệu vào các Textbox
        private void CURD__Control__EnableDisable()
        {
            Lib.ReadOnlyControl(gbContent, isViewOrEdit);
            tbCode.ReadOnly = tbImages.ReadOnly = tbAmount.ReadOnly = tbPrice.ReadOnly = true;
            btDanger.Enabled = !isViewOrEdit;
            cbCatalog.DropDownStyle = cbSupplier.DropDownStyle = cbStatus.DropDownStyle = isViewOrEdit ? ComboBoxStyle.Simple : ComboBoxStyle.DropDown;
        }

        // kiểm tra các textbox không trống trước khi lưu vào db
        private bool inputValidate()
        {
            bool check = Lib.CheckInputNoEmpty(gbContent);

            if (!check)
            {
                ShowMessagebox.Error("Không có dữ liệu đầu vào!");
                return false;
            }

            return check;
        }

        // mở form chọn hình ảnh
        private void openDialog()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Chọn hình ảnh";
                dlg.Filter = "Kiểu hình ảnh | *.jpg;*.jpeg;*.png;";
                dlg.Multiselect = true;

                DialogResult dr = dlg.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    isChangeImage = true;
                    string[] nameImages = dlg.SafeFileNames;
                    tbImages.Text = string.Join(", ", nameImages);
                    pathImage = Path.GetDirectoryName(dlg.FileName);

                    loadComboxboImage(nameImages);
                }
            }
        }

        // hàm đóng gói dữ liệu (gán các giá trị vào đối tượng tương ứng)
        private void package()
        {
            this.product = new Product
            {
                ProductCode = tbCode.Text.Trim(),
                Name = tbName.Text.Trim(),
                Image = tbImages.Text.Trim(),
                Amount = int.Parse(tbAmount.Text.Trim()),
                Price = Lib.ConvertIntFromPrice(tbPrice),
                CatalogID = cbCatalog.SelectedValue?.ToString(),
                SupplierID = cbSupplier.SelectedValue?.ToString(),
                StatusID = cbStatus.SelectedValue?.ToString(),
                CreateDate = date
            };
        }

        // Xử lý lưu dữ liệu vào db
        private void save()
        {
            package();
            bProduct b = new bProduct();
            string mess = $"{product.ProductCode}: {product.Name}";

            if (!b.CheckExists(product.ProductCode))
            {
                ShowMessagebox.Error($"Không tồn tại [{mess}]!");
                return;
            }

            bool result = b.Update(product);

            if (!result)
            {
                ShowMessagebox.Error($"Không thể lưu {mess}!");
                return;
            }

            this.DialogResult = DialogResult.Yes;
            ShowMessagebox.Susscess($"Lưu {mess} thành công.");

            if (isChangeImage)
            {
                Lib.ImageImport(cbImages.SelectedItem.ToString(), pathImage);
            }

            isViewOrEdit = true;
            CURD__Control__EnableDisable();
            CURD__Button();
        }
    }
}