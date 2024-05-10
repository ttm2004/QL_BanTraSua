using ShopSimple.Controller;
using ShopSimple.Library;
using ShopSimple.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ShopSimple.View.Detail
{
    public delegate void SendProductChoice(string productCode);

    public delegate void SendNewCustomer(string phone);

    public partial class frmInvoice__Detail : Form
    {
        private DateTime date;
        private bool isAdd, isViewOrEdit;
        private bool isSave = false, isStartCombobox = true;
        private string InvoiceCode;
        private string code__selected__prod;
        private int TotalProduct = 0;
        private Invoice _invoice;
        private List<TempProduct> listProd = new List<TempProduct>(); // danh sách sản phẩm, thay đổi dữ liệu để không ảnh hưởng tới db
        private List<InvoiceDetail> listInvoiceDetail = new List<InvoiceDetail>();

        public frmInvoice__Detail(bool IsAdd)
        {
            InitializeComponent();
            this.isAdd = IsAdd;
            this.isViewOrEdit = true;
            load();
        }

        public frmInvoice__Detail(string Code, bool IsViewOrEdit)
        {
            InitializeComponent();
            this.isViewOrEdit = IsViewOrEdit;
            this.isAdd = false;
            load(Code);
        }

        private void dgvList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            dgvList.Rows.Cast<DataGridViewRow>().ToList().ForEach(i => i.MinimumHeight = 100);
            dgvList.AutoSizeColumnsMode = WindowState == FormWindowState.Maximized ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.None;
        }

        private void cbPhone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isStartCombobox) return;
            tbNameCust.Text = string.IsNullOrEmpty(cbPhone.Text) ? "" : new bCustomer().GetDetail(cbPhone.Text?.ToString()).Name;
        }

        private void tbProdAmount_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tbProdAmount.Text.Trim(), out _) || string.IsNullOrEmpty(tbProdAmount.Text.Trim()))
                return;

            var amount = int.Parse(tbProdAmount.Text.Trim());
            var price = Lib.ConvertIntFromPrice(tbProdPrice);

            tbProdTotal.Text = Lib.ConvertPrice((price * amount).ToString(), true);
        }

        private void btPrimary_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvList.RowCount == 0)
                {
                    ShowMessagebox.Error("Không thể lưu dữ liệu!");
                    return;
                }

                saveInvoice();
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
                if (isAdd)
                {
                    if (ShowMessagebox.Question("Bạn có muốn huỷ đơn bán hàng này không?") == DialogResult.No)
                        return;

                    this.Dispose();
                }
                else
                {
                    if (ShowMessagebox.Question("Bạn có muốn xoá đơn bán hàng này không?") == DialogResult.No)
                        return;

                    deleteInvoice();
                }
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
                if (isAdd)
                {
                    Lib.ClearControl(gbInforInvoice, false);
                    Lib.ClearControl(pnProd, false);
                    dgvList.Rows.Clear();
                    resetInformation();
                }
                else
                {
                    dgvList.Rows.Clear();
                    clearProdControl();
                    loadList();
                    resetInformation();
                }
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btAddNewCustomer_Click(object sender, EventArgs e)
        {
            using (var frm = new frmCustomer__Detail(true, getSenderCustomer))
            {
                frm.ShowDialog();
            }
        }

        private void btProdFind_Click(object sender, EventArgs e)
        {
            using (var frm = new frmFindProduct(getSenderProduct))
            {
                frm.ShowDialog();
            }
        }

        private void btProdClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearProdControl();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btProdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                updateProdList();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btProdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                deleteProdList();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btProdAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                addProdList();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            code__selected__prod = dgvList.RowCount != 0 ? dgvList.CurrentRow.Cells[2].Value.ToString() : null;

            if (code__selected__prod == null) return;

            var d = listProd.FirstOrDefault(i => i.Id == code__selected__prod); // lấy dữ liệu của sản phẩm trong danh tạm của form, khi chỉnh sửa hay thay đổi điều không ảnh hưởng tới db

            if (d == null) return;

            tbProdCode.Text = d.Id;
            tbProdName.Text = d.Name;
            tbProdAmount.Text = d.Amount.ToString();
            tbProdPrice.Text = Lib.ConvertPrice(new bProduct().GetDetail(code__selected__prod).Price.ToString(), true);
            tbProdTotal.Text = Lib.ConvertPrice(d.Price.ToString(), true);
            Lib.ImageLoadOneImage(new bProduct().GetDetail(code__selected__prod).Image, picMain);
        }

        private void frmInvoice__Detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSave || dgvList.RowCount == 0)
            {
                e.Cancel = false;
                return;
            }

            if (ShowMessagebox.Question("Bạn có muốn thoát Đơn bán hàng không?") == DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        // function
        private void load()
        {
            getCombobox();
            resetInformation();
        }

        private void load(string code)
        {
            getCombobox();
            CURD__Control__EnableDisable();
            binding(code);
            resetInformation();

            btPrimary.Visible = false;
            btDanger.Text = "Xoá đơn";
            eventRole();
        }

        // kiểm tra phân quyền để hiển thị chức năng đúng với phân quyền người dùng.
        private void eventRole()
        {
            if (Temp.IsAdmin) return;
            btDanger.Visible = Temp.User.Equals(tbUser.Text.Trim());
        }

        // cho phép hoặc không cho phép thao tác khi ở các trạng thái thêm, sửa hoặc chi tiết
        private void CURD__Control__EnableDisable()
        {
            Lib.ReadOnlyControl(pnProd, isViewOrEdit);
            Lib.ReadOnlyControl(gbInforInvoice, isViewOrEdit);
            tbCode.ReadOnly = tbUser.ReadOnly = tbNameEmp.ReadOnly = tbNameCust.ReadOnly = tbDate.ReadOnly = true;

            if (!isAdd)
            {
                cbPhone.DropDownStyle = isViewOrEdit ? ComboBoxStyle.Simple : ComboBoxStyle.DropDown;
                btAddNewCustomer.Enabled = btProdDelete.Enabled = btProdEdit.Enabled = btProdAddToList.Enabled = btProdFind.Enabled = btProdClear.Enabled = !isViewOrEdit;
            }
        }

        // hiển thị dữ liệu đã lưu lên các control
        private void binding(string code)
        {
            _invoice = new bInvoice().GetDetail(code);
            date = _invoice.Date;
            binding__control();
            binding__list();
        }

        private void binding__control()
        {
            tbCode.Text = _invoice.InvoiceCode;
            tbDate.Text = Lib.ConvertDateToString(_invoice.Date);
            tbUser.Text = _invoice.UserID;
            tbNameCust.Text = _invoice.Customer.Name;
            tbNameEmp.Text = _invoice.User.Name;
            TotalProduct = _invoice.Total;
            cbPhone.SelectedValue = _invoice.CustomerPhone;
            lblTotal.Text = $"{lblTotal.Tag}: {Lib.ConvertPrice(TotalProduct.ToString(), true)}đ";
            lblCount.Text = $"{lblCount.Tag} {new bInvoiceDetail().GetCount(_invoice.InvoiceCode)}";
            lblQuantity.Text = $"{lblQuantity.Tag} {new bInvoiceDetail().GetQuantity(_invoice.InvoiceCode)}";
        }

        // tải danh sách đã lưu
        private void binding__list()
        {
            try
            {
                var list = new bInvoiceDetail().GetList(_invoice.InvoiceCode);
                list.ToList().ForEach(i =>
                {
                    var dProd = new bProduct().GetDetail(i.ProductID);
                    var d = new TempProduct
                    {
                        Id = dProd.ProductCode,
                        Name = dProd.Name,
                        Image = dProd.Image,
                        Catalog = dProd.CatalogID,
                        Supplier = dProd.SupplierID,
                        Amount = i.Quantity,
                        Price = i.Price,
                        CreateDate = dProd.CreateDate,
                        Status = dProd.StatusID
                    };
                    listProd.Add(d);
                });
                loadList();
            }
            catch
            {
                dgvList.DataSource = null;
            }
        }

        // làm mới lại các thông tin chính trong form
        private void resetInformation()
        {
            resetTime();
            setReportFromProdList();
            InvoiceCode = isAdd ? new bInvoice().CreateKey() : _invoice.InvoiceCode;
            gbInforInvoice.Text = $"{gbInforInvoice.Tag}: #{InvoiceCode}";
            tbCode.Text = InvoiceCode;

            if (isAdd)
            {
                tbUser.Text = Temp.User;
                tbNameEmp.Text = new bUser().GetDetail(Temp.User).Name;
            }
        }

        // làm mới thời gian
        private void resetTime()
        {
            if (isAdd)
            {
                date = DateTime.Now;
                tbDate.Text = Lib.ConvertDateToString(date);
            }
        }

        // đóng gói dữ liệu cho đơn bán hàng
        private void package()
        {
            packageInvoice();
            packageInvoiceDetail();
        }

        // đóng gói đơn tổng hợp
        private void packageInvoice()
        {
            _invoice = new Invoice
            {
                InvoiceCode = InvoiceCode,
                UserID = tbUser.Text.Trim(),
                CustomerPhone = cbPhone.SelectedValue?.ToString(),
                Date = date,
                Total = TotalProduct
            };
        }

        // đóng gói đơn chi tiết
        private void packageInvoiceDetail()
        {
            listInvoiceDetail = new List<InvoiceDetail>();
            listInvoiceDetail.AddRange(listProd.Select(i => new InvoiceDetail
            {
                InvoiceID = InvoiceCode,
                ProductID = i.Id,
                Quantity = i.Amount,
                Price = i.Price
            }));
        }

        // hiển thị thông tin tổng hợp khi thay đổi dữ liệu của các thành phần trong danh sách sản phẩm
        private void setReportFromProdList()
        {
            TotalProduct = 0;
            listProd.ForEach(i => TotalProduct += i.Price);

            lblCount.Text = $"{lblCount.Tag} {dgvList.RowCount}";
            lblQuantity.Text = $"{lblQuantity.Tag} {listProd.Sum(e => e.Amount)}";
            lblTotal.Text = $"{lblTotal.Tag} {Lib.ConvertPrice(TotalProduct.ToString(), true)}đ";
        }

        // tải dữ liệu lên datagridview
        private void loadList()
        {
            dgvList.Rows.Clear();
            dgvList.Rows.AddRange(listProd.Select((i, count) => new DataGridViewRow
            {
                Cells =
                    {
                        new DataGridViewTextBoxCell { Value = count + 1},
                        new DataGridViewImageCell {   Value = Lib.ImageLoad__ForList(new bProduct().GetDetail(i.Id).Image) },
                        new DataGridViewTextBoxCell { Value = i.Id },
                        new DataGridViewTextBoxCell { Value = i.Name },
                        new DataGridViewTextBoxCell { Value = new bCatalog().GetDetail(new bProduct().GetDetail(i.Id).CatalogID).Name },
                        new DataGridViewTextBoxCell { Value = new bSupplier().GetDetail(new bProduct().GetDetail(i.Id).SupplierID).Name },
                        new DataGridViewTextBoxCell { Value = i.Amount },
                        new DataGridViewTextBoxCell { Value = Lib.ConvertPrice(new bProduct().GetDetail(i.Id).Price.ToString(), true) },
                        new DataGridViewTextBoxCell { Value = Lib.ConvertPrice(i.Price.ToString(), true) }
                    }
            }).ToArray());

            setReportFromProdList();
        }

        // nhận giá trị từ control trong thông tin sản phẩm
        private TempProduct getValueProduct()
        {
            return new TempProduct
            {
                Id = tbProdCode.Text.Trim(),
                Name = tbProdName.Text.Trim(),
                Amount = int.Parse(tbProdAmount.Text.Trim()),
                Price = Lib.ConvertIntFromPrice(tbProdTotal)
            };
        }

        // thêm sản phẩm vào danh sách sản phẩm
        private void addProdList()
        {
            if (!checkInputProdNotEmpty())
            {
                ShowMessagebox.Error("không có dữ liệu để thêm vào!");
                return;
            }

            var data = getValueProduct();

            if (string.IsNullOrEmpty(data.Id))
            {
                ShowMessagebox.Error("Không có mã sản phẩm!");
                return;
            }

            if (listProd.FindIndex(e => e.Id.Equals(data.Id)) >= 0)
            {
                ShowMessagebox.Error($"Sản phẩm {data.Id}: {data.Name} đã tồn tại trong danh sách!");
                return;
            }

            listProd.Add(data);

            clearProdControl();
            loadList();
        }

        // sửa sản phẩm trong danh sách
        private void updateProdList()
        {
            if (!checkInputProdNotEmpty())
            {
                ShowMessagebox.Error("không có dữ liệu để sửa!");
                return;
            }

            var data = getValueProduct();

            if (string.IsNullOrEmpty(data.Id))
            {
                ShowMessagebox.Error("Không có mã sản phẩm!");
                return;
            }

            int index = listProd.FindIndex(e => e.Id.Equals(data.Id));

            if (index < 0)
            {
                ShowMessagebox.Error($"Không tồn tại \'{data.Id}: {data.Name}\' trong danh sách!");
                return;
            }

            listProd[index] = data;

            clearProdControl();
            loadList();
        }

        // xoá snar phẩm trong danh sách
        private void deleteProdList()
        {
            var idProd = tbProdCode.Text.Trim();

            if (!checkInputProdNotEmpty())
            {
                ShowMessagebox.Error("không có dữ liệu để xoá!");
                return;
            }

            if (string.IsNullOrEmpty(idProd))
            {
                ShowMessagebox.Error("Không có mã sản phẩm!");
                return;
            }

            int index = listProd.FindIndex(e => e.Id.Equals(idProd));

            if (index >= 0)
            {
                listProd.RemoveAt(index);
                clearProdControl();
                loadList();
                return;
            }

            ShowMessagebox.Error($"Không có mã {idProd} trong danh sách!");
        }

        private void getCombobox()
        {
            getComboboxPhone();
        }

        private void getComboboxPhone()
        {
            cbPhone.DataSource = new bCustomer().Select();
            cbPhone.DisplayMember = "Display";
            cbPhone.ValueMember = "Value";
            isStartCombobox = false;
            cbPhone.SelectedIndex = -1;
        }

        private void saveInvoice()
        {
            package();
            bInvoice b = new bInvoice();
            string mess = $"#{_invoice.InvoiceCode}";

            if (b.CheckExists(_invoice.InvoiceCode) && isAdd)
            {
                ShowMessagebox.Error($"Đã tồn tại đơn bán hàng #{_invoice.InvoiceCode}!");
                return;
            }

            foreach (var i in listInvoiceDetail)
            {
                if (i.Quantity > new bProduct().GetDetail(i.ProductID).Amount)
                {
                    ShowMessagebox.Error($"Số lượng của \'{i.ProductID}: {new bProduct().GetDetail(i.ProductID).Name}, ({i.Quantity})\' lớn hơn số lượng tồn kho ({new bProduct().GetDetail(i.ProductID).Amount})!");
                    return;
                }
            }

            bool result = isAdd ? new bInvoice().Add(_invoice) : new bInvoice().Update(_invoice);

            if (!result)
            {
                ShowMessagebox.Error($"Thêm {mess} thất bại!");
                return;
            }

            result = saveInvoiceDetail();

            if (!result)
            {
                new bInvoice().Delete(_invoice.InvoiceCode);
                ShowMessagebox.Error("Không thể lưu đơn chi tiết!");
                return;
            }

            ShowMessagebox.Susscess($"Thêm {mess} Thành công.");

            if (!isAdd)
            {
                isViewOrEdit = true;
                CURD__Control__EnableDisable();
            }
            else
            {
                this.DialogResult = DialogResult.Yes;
                isSave = true;
                this.Close();
            }
        }

        private bool saveInvoiceDetail()
        {
            var listBak = new List<InvoiceDetail>();
            var listProdBak = new List<TempProduct>();

            try
            {
                foreach (var i in listInvoiceDetail)
                {
                    bool rs = new bInvoiceDetail().Add(i);

                    if (!rs)
                    {
                        if (listBak.Count != 0)
                        {
                            listBak.ForEach(e => new bInvoiceDetail().Delete(e.InvoiceID, e.ProductID));
                            listProdBak.ForEach(e => new bProduct().UpdateAmount(e.Id, e.Amount, true));
                        }

                        return false;
                    }

                    listBak.Add(i);

                    rs = new bProduct().UpdateAmount(i.ProductID, i.Quantity, false);

                    if (!rs)
                    {
                        listBak.ForEach(e => new bInvoiceDetail().Delete(e.InvoiceID, e.ProductID));
                        listProdBak.ForEach(e => new bProduct().UpdateAmount(e.Id, e.Amount, true));
                        ShowMessagebox.Error("Không thể cập nhật lại số lượng sản phẩm!");
                        return false;
                    }

                    var d = new TempProduct { Id = i.ProductID, Amount = i.Quantity };
                    listProdBak.Add(d);
                }
            }
            catch
            {
                listBak.ForEach(i => new bInvoiceDetail().Delete(i.InvoiceID, i.ProductID));
            }
            return true;
        }

        // xoá hoá đơn
        private void deleteInvoice()
        {
            package();
            var listProdBak = new List<TempProduct>();
            var listInvoiceBak = new List<InvoiceDetail>();
            bInvoice b = new bInvoice();
            string mess = $"#{_invoice.InvoiceCode}: {Lib.ConvertDateToString(_invoice.Date)}";

            if (!b.CheckExists(_invoice.InvoiceCode))
            {
                ShowMessagebox.Error($"Không tồn tại {mess} trong hệ thống!");
                return;
            }

            foreach (var i in listInvoiceDetail)
            {
                bool rs = new bInvoiceDetail().Delete(i.InvoiceID, i.ProductID);

                if (!rs)
                {
                    ShowMessagebox.Error($"Không thể xoá {i.InvoiceID}: {i.ProductID} - {i.Product.Name}");
                    listInvoiceBak.ForEach(e => new bInvoiceDetail().Add(e));
                    return;
                }

                listInvoiceBak.Add(i);
            }

            foreach (var i in listInvoiceBak)
            {
                var prod = new bProduct().GetDetail(i.ProductID);
                bool rs = new bProduct().UpdateAmount(i.ProductID, i.Quantity, true);

                if (!rs)
                {
                    ShowMessagebox.Error($"Không thể xoá {i.ProductID}: {i.Product.Name}");
                    rollbackForDelete(listProdBak, listInvoiceBak);
                    return;
                }

                var dPO = new TempProduct
                {
                    Id = prod.ProductCode,
                    Name = prod.Name,
                    Catalog = prod.CatalogID,
                    Supplier = prod.SupplierID,
                    Image = prod.Image,
                    Amount = i.Quantity,
                    Price = prod.Price,
                    Status = prod.StatusID,
                    CreateDate = prod.CreateDate
                };

                listProdBak.Add(dPO);
            }

            bool result = new bInvoice().Delete(_invoice.InvoiceCode);

            if (!result)
            {
                ShowMessagebox.Error($"Không thể xoá {mess}!");
                rollbackForDelete(listProdBak, listInvoiceBak);
                return;
            }

            ShowMessagebox.Susscess($"Xoá đơn nhập {mess} thành công.");

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        // khôi phục lại dữ liệu đã xoá
        private void rollbackForDelete(List<TempProduct> listProdBak, List<InvoiceDetail> listInvoiceBak)
        {
            listProdBak.ForEach(e =>
            {
                var d = new Product
                {
                    ProductCode = e.Id,
                    Name = e.Name,
                    CatalogID = e.Catalog,
                    SupplierID = e.Supplier,
                    Image = e.Image,
                    Amount = e.Amount,
                    Price = e.Price,
                    StatusID = e.Status,
                    CreateDate = e.CreateDate
                };

                new bProduct().UpdateAmount(d.ProductCode, d.Amount, false);
            });
            listInvoiceBak.ForEach(e => new bInvoiceDetail().Add(e));
        }

        private bool checkInputProdNotEmpty()
        {
            return Lib.CheckControlEmpty(pnProd);
        }

        // Làm mới lại thông tin sản phẩm
        private void clearProdControl()
        {
            tbProdCode.Clear();
            tbProdName.Clear();
            tbProdAmount.Clear();
            tbProdPrice.Clear();
            tbProdTotal.Clear();
            Lib.ImageLoad__Null(picMain);
        }

        // xử lý dữ liệu sau khi thêm khách hàng
        private void getSenderCustomer(string phone)
        {
            getComboboxPhone();
            cbPhone.SelectedValue = phone;
            tbNameCust.Text = new bCustomer().GetDetail(phone).Name;
        }

        // xử lý dữ liệu sau khi thêm khách hàng
        private void getSenderProduct(string productCode)
        {
            var d = new bProduct().GetDetail(productCode);
            tbProdCode.Text = productCode;
            tbProdName.Text = d.Name;
            tbProdAmount.Text = "1";
            tbProdPrice.Text = Lib.ConvertPrice(d.Price.ToString(), true);
            tbProdTotal.Text = Lib.ConvertPrice((d.Price * int.Parse(tbProdAmount.Text.ToString())).ToString(), true);
            Lib.ImageLoadOneImage(new bProduct().GetDetail(productCode).Image, picMain);
        }
    }
}