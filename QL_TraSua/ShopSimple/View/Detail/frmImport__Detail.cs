using ShopSimple.Controller;
using ShopSimple.Library;
using ShopSimple.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShopSimple.View.Detail
{
    public partial class frmImport__Detail : Form
    {
        private DateTime date;
        private bool isAdd, isViewOrEdit;
        private bool isSave = false;
        private bool isChangeImage = false; // kiểm tra tình trạng có thay đổi ảnh hay không, dùng trong trường hợp đã thêm hình ảnh trước đó
        private string InvoiceCode;
        private string pathImage, code__selected__prod;
        private int TotalProduct = 0;
        private Import _invoice;
        private List<TempProduct> listProd = new List<TempProduct>(); // danh sách sản phẩm, thay đổi dữ liệu để không ảnh hưởng tới db
        private List<ImagePathList> listProdPathImage = new List<ImagePathList>(); // danh sách chứa thông tin hình ảnh, sử dụng khi thêm hình ảnh cho sản phẩm nhưng chưa lưu dữ liệu vào db
        private List<ImportDetail> listInvoiceDetail = new List<ImportDetail>();

        public frmImport__Detail(bool IsAdd)
        {
            InitializeComponent();
            this.isAdd = IsAdd;
            this.isViewOrEdit = true;
            load();
        }

        public frmImport__Detail(string Code, bool IsViewOrEdit)
        {
            InitializeComponent();
            this.isViewOrEdit = IsViewOrEdit;
            this.isAdd = false;
            load(Code);
        }

        private void tbProdPrice_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbProdPrice.Text.Trim())) return;

            tbProdPrice.Text = Lib.ConvertPrice(tbProdPrice.Text.Trim(), false);
        }

        private void tbProdPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbProdPrice.Text.Trim())) return;

            tbProdPrice.Text = Lib.ConvertPrice(tbProdPrice.Text.Trim(), true);
        }

        private void frmImport__Detail_SizeChanged(object sender, EventArgs e)
        {
            dgvList.AutoSizeColumnsMode = WindowState == FormWindowState.Maximized ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.None;
        }

        private void dgvList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            dgvList.Rows.Cast<DataGridViewRow>().ToList().ForEach(i => i.MinimumHeight = 100);
            dgvList.AutoSizeColumnsMode = WindowState == FormWindowState.Maximized ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.None;
        }

        private void cbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAdd || isChangeImage)
            {
                string tempPath = Path.Combine(pathImage, cbImages.SelectedItem.ToString());
                picMain.Image = File.Exists(tempPath) ? Image.FromFile(tempPath) : Properties.Resources.noImages;
            }
            else if (isViewOrEdit)
            {
                Lib.ImageLoad(cbImages.Text.ToString(), picMain);
            }
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
                    if (ShowMessagebox.Question("Bạn có muốn huỷ đơn nhập hàng này không?") == DialogResult.No)
                        return;

                    this.Dispose();
                }
                else
                {
                    if (ShowMessagebox.Question("Bạn có muốn xoá đơn nhập hàng này không?") == DialogResult.No)
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

        private void btProdRefreshCode_Click(object sender, EventArgs e)
        {
            try
            {
                tbProdCode.Text = new bProduct().CreateKey();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
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

        private void btProdOpenDialog_Click(object sender, EventArgs e)
        {
            try
            {
                openDialog();
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
            tbProdImage.Text = d.Image;
            tbProdAmount.Text = d.Amount.ToString();
            tbProdPrice.Text = Lib.ConvertPrice(d.Price.ToString(), true);
            cbCatalog.SelectedValue = d.Catalog;
            cbSupplier.SelectedValue = d.Supplier;
            cbStatus.SelectedValue = d.Status;
            loadComboboxImage(d.Image.Split(','));
        }

        private void frmImport__Detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSave || dgvList.RowCount == 0)
            {
                e.Cancel = false;
                return;
            }

            if (ShowMessagebox.Question("Bạn có muốn thoát Nhập hàng không?") == DialogResult.No)
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
        }

        // cho phép hoặc không cho phép thao tác khi ở các trạng thái thêm, sửa hoặc chi tiết
        private void CURD__Control__EnableDisable()
        {
            Lib.ReadOnlyControl(pnProd, isViewOrEdit);
            Lib.ReadOnlyControl(gbInforInvoice, isViewOrEdit);
            tbCode.ReadOnly = tbUser.ReadOnly = tbName.ReadOnly = tbDate.ReadOnly = true;
            btProdOpenDialog.Enabled = btProdEdit.Enabled = btProdDelete.Enabled = btProdRefreshCode.Enabled = btProdClear.Enabled = btProdAddToList.Enabled = !isViewOrEdit;
            cbCatalog.DropDownStyle = cbSupplier.DropDownStyle = cbStatus.DropDownStyle = isViewOrEdit ? ComboBoxStyle.Simple : ComboBoxStyle.DropDown;
        }

        // hiển thị dữ liệu đã lưu lên các control
        private void binding(string code)
        {
            _invoice = new bImport().GetDetail(code);
            date = _invoice.Date;
            binding__control();
            binding__list();
        }

        private void binding__control()
        {
            tbCode.Text = _invoice.ImportCode;
            tbDate.Text = Lib.ConvertDateToString(_invoice.Date);
            tbUser.Text = _invoice.UserID;
            tbName.Text = _invoice.Admin.Name;
            TotalProduct = _invoice.Total;
            lblTotal.Text = $"{lblTotal.Tag}: {Lib.ConvertPrice(TotalProduct.ToString(), true)}đ";
            lblCount.Text = $"{lblCount.Tag} {new bImportDetail().GetCount(_invoice.ImportCode)}";
            lblQuantity.Text = $"{lblQuantity.Tag} {new bImportDetail().GetQuantity(_invoice.ImportCode)}";
        }

        // tải danh sách đã lưu
        private void binding__list()
        {
            try
            {
                var list = new bImportDetail().GetList(_invoice.ImportCode);
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
                        Amount = dProd.Amount,
                        Price = dProd.Price,
                        CreateDate = dProd.CreateDate,
                        Status = dProd.StatusID
                    };
                    d.Amount = i.Quantity;
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
            InvoiceCode = isAdd ? new bImport().CreateKey() : _invoice.ImportCode;
            gbInforInvoice.Text = $"{gbInforInvoice.Tag}: #{InvoiceCode}";
            tbCode.Text = InvoiceCode;
            tbUser.Text = Temp.User;
            tbName.Text = new bAdmin().GetDetail(Temp.User).Name;
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

        // đóng gói dữ liệu cho đơn nhập hàng
        private void package()
        {
            packageInvoice();
            packageInvoiceDetail();
        }

        // đóng gói đơn tổng hợp
        private void packageInvoice()
        {
            _invoice = new Import
            {
                ImportCode = InvoiceCode,
                UserID = tbUser.Text.Trim(),
                Date = date,
                Total = TotalProduct
            };
        }

        // đóng gói đơn chi tiết
        private void packageInvoiceDetail()
        {
            listInvoiceDetail = new List<ImportDetail>();
            listInvoiceDetail.AddRange(listProd.Select(i => new ImportDetail
            {
                ImportID = InvoiceCode,
                ProductID = i.Id,
                Quantity = i.Amount,
                Price = i.Price
            }));
        }

        // hiển thị thông tin tổng hợp khi thay đổi dữ liệu của các thành phần trong danh sách sản phẩm
        private void setReportFromProdList()
        {
            TotalProduct = 0;
            listProd.ForEach(i => TotalProduct += i.Amount * i.Price);

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
                        new DataGridViewImageCell { Value = isAdd ? Lib.ImageLoad__ForList(String.Join(", ", i.Image), listProdPathImage[count].Path) : Lib.ImageLoad__ForList(String.Join(", ", i.Image)) },
                        new DataGridViewTextBoxCell { Value = i.Id },
                        new DataGridViewTextBoxCell { Value = i.Name },
                        new DataGridViewTextBoxCell { Value = new bCatalog().GetDetail(i.Catalog).Name },
                        new DataGridViewTextBoxCell { Value = new bSupplier().GetDetail(i.Supplier).Name },
                        new DataGridViewTextBoxCell { Value = i.Amount },
                        new DataGridViewTextBoxCell { Value = Lib.ConvertPrice(i.Price.ToString(), true) },
                        new DataGridViewTextBoxCell { Value = Lib.ConvertPrice((i.Price * i.Amount).ToString(), true) }
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
                Catalog = cbCatalog.SelectedValue.ToString(),
                Supplier = cbSupplier.SelectedValue?.ToString(),
                Image = tbProdImage.Text.Trim(),
                Amount = int.Parse(tbProdAmount.Text.Trim()),
                Price = int.Parse(Lib.ConvertPrice(tbProdPrice.Text.Trim(), false)),
                CreateDate = date,
                Status = cbStatus.SelectedValue?.ToString()
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
            var imagePath = new ImagePathList
            {
                Id = data.Id,
                Path = pathImage,
                Image = data.Image
            };
            listProdPathImage.Add(imagePath);

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
            int indexPath = listProdPathImage.FindIndex(e => e.Id == data.Id);
            listProdPathImage[indexPath].Image = data.Image;

            if (isChangeImage)
                listProdPathImage[indexPath].Path = pathImage;

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
                int indexPath = listProdPathImage.FindIndex(e => e.Id == idProd);
                clearProdControl();
                loadList();
                listProdPathImage.RemoveAt(indexPath);
                return;
            }

            ShowMessagebox.Error($"Không có mã {idProd} trong danh sách!");
        }

        private void getCombobox()
        {
            cbCatalog.DataSource = new bCatalog().Select();
            cbSupplier.DataSource = new bSupplier().Select();
            cbStatus.DataSource = new bStatus().Select();
            cbCatalog.DisplayMember = cbSupplier.DisplayMember = cbStatus.DisplayMember = "Display";
            cbCatalog.ValueMember = cbSupplier.ValueMember = cbStatus.ValueMember = "Value";
            cbCatalog.SelectedIndex = cbSupplier.SelectedIndex = cbStatus.SelectedIndex = isAdd ? -1 : 0;
        }

        // mở hộp thoại thêm hình cho sản phẩm
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
                    tbProdImage.Text = string.Join(", ", nameImages);
                    pathImage = Path.GetDirectoryName(dlg.FileName);

                    loadComboboxImage(nameImages);
                }
                else
                {
                    isChangeImage = false;
                }
            }
        }

        private void loadComboboxImage(string[] nameImages)
        {
            cbImages.Items.Clear();
            cbImages.Items.AddRange(nameImages.Select(i => i.Trim()).ToArray());
            cbImages.SelectedIndex = 0;
        }

        private void saveProd()
        {
            var bak = new List<string>();
            var bakImageImport = new List<ImagePathList>();

            foreach (var i in listProd)
            {
                var data = new Product
                {
                    ProductCode = i.Id,
                    Name = i.Name,
                    CatalogID = i.Catalog,
                    SupplierID = i.Supplier,
                    Image = i.Image,
                    Amount = i.Amount,
                    Price = i.Price,
                    StatusID = i.Status,
                    CreateDate = i.CreateDate
                };

                bool rs = new bProduct().Add(data);

                if (!rs)
                {
                    bak.ForEach(e => new bProduct().Delete(e));
                    return;
                }

                bak.Add(data.ProductCode);
            }

            foreach (var i in listProdPathImage)
            {
                string[] img = i.Image.Split(',');
                img.Select(e => e.Trim()).ToList().ForEach(e =>
                {
                    try
                    {
                        Lib.ImageImport(e, i.Path);
                        bakImageImport.Add(i);
                    }
                    catch
                    {
                        bakImageImport.ForEach(x =>
                        {
                            img = x.Image.Split(',');
                            img.Select(z => z.Trim()).ToList().ForEach(z => Lib.ImageDelete(z));
                        });
                    }
                });
            }
        }

        private void saveInvoice()
        {
            package();
            bImport b = new bImport();
            string mess = $"#{_invoice.ImportCode}";

            if (b.CheckExists(_invoice.ImportCode) && isAdd)
            {
                ShowMessagebox.Error($"Đã tồn tại đơn nhập hàng #{_invoice.ImportCode}!");
                return;
            }

            bool result = isAdd ? new bImport().Add(_invoice) : new bImport().Update(_invoice);

            if (!result)
            {
                ShowMessagebox.Error($"Thêm {mess} thất bại!");
                return;
            }

            saveProd();
            saveInvoiceDetail();
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

        private void saveInvoiceDetail()
        {
            var listBak = new List<ImportDetail>();

            try
            {
                listInvoiceDetail.ForEach(i =>
                {
                    bool rs = new bImportDetail().Add(i);
                    if (rs) listBak.Add(i);
                });
            }
            catch
            {
                listBak.ForEach(i => new bImportDetail().Delete(i.ImportID, i.ProductID));
            }
        }

        // xoá hoá đơn
        private void deleteInvoice()
        {
            package();
            var listProdBak = new List<TempProduct>();
            var listInvoiceBak = new List<ImportDetail>();
            bImport b = new bImport();
            string mess = $"#{_invoice.ImportCode}: {_invoice.ImportCode}";

            if (!b.CheckExists(_invoice.ImportCode))
            {
                ShowMessagebox.Error($"Không tồn tại {mess} trong hệ thống!");
                return;
            }

            int countExists = 0;
            listInvoiceDetail.ToList().ForEach(e => countExists += new bInvoiceDetail().CheckExistsProduct(e.ProductID) ? 1 : 0);

            if (countExists > 0)
            {
                ShowMessagebox.Error($"Không thể xoá đơn nhập hàng do có {countExists} sản phẩm đã bán trong đơn nhập hàng này.");
                return;
            }

            foreach (var i in listInvoiceDetail)
            {
                bool rs = new bImportDetail().Delete(i.ImportID, i.ProductID);

                if (!rs)
                {
                    ShowMessagebox.Error($"Không thể xoá {i.ImportID}: {i.ProductID} - {i.Product.Name}");
                    listInvoiceBak.ForEach(e => new bImportDetail().Add(e));
                    return;
                }

                listInvoiceBak.Add(i);
            }

            foreach (var i in listInvoiceBak)
            {
                var prod = new bProduct().GetDetail(i.ProductID);
                bool rs = new bProduct().Delete(i.ProductID);

                if (!rs)
                {
                    ShowMessagebox.Error($"Không thể xoá {prod.ProductCode}: {prod.Name}");
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

                        new bProduct().Add(d);
                    });
                    listInvoiceBak.ForEach(e => new bImportDetail().Add(e));
                    return;
                }

                var dPO = new TempProduct
                {
                    Id = prod.ProductCode,
                    Name = prod.Name,
                    Catalog = prod.CatalogID,
                    Supplier = prod.SupplierID,
                    Image = prod.Image,
                    Amount = prod.Amount,
                    Price = prod.Price,
                    Status = prod.StatusID,
                    CreateDate = prod.CreateDate
                };

                listProdBak.Add(dPO);
            }

            bool result = new bImport().Delete(_invoice.ImportCode);

            if (!result)
            {
                ShowMessagebox.Error($"Không thể xoá {mess}!");
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

                    new bProduct().Add(d);
                });
                listInvoiceBak.ForEach(e => new bImportDetail().Add(e));
                return;
            }

            ShowMessagebox.Susscess($"Xoá đơn nhập {mess} thành công.");

            var lstImageNotDelete = new List<string>();

            foreach(var i in listProdBak)
            {
                string[] imgs;

                try
                {
                    imgs = i.Image.Split(',');

                }
                catch
                {
                    imgs = new string[] {i.Image };
                }

                imgs.ToList().ForEach(e =>
                {
                    try
                    {
                        Lib.ImageDelete(e.Trim());
                    }
                    catch
                    {
                        lstImageNotDelete.Add(e);
                    }
                });
            }

            if (lstImageNotDelete.Count > 0)
            {
                ShowMessagebox.Error($"Không thể xoá các hình ảnh [{String.Join(", ", lstImageNotDelete.ToArray())}]!");
            }

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private bool checkInputProdNotEmpty()
        {
            return Lib.CheckControlEmpty(pnProd);
        }

        private void clearProdControl()
        {
            tbProdCode.Clear();
            tbProdName.Clear();
            tbProdImage.Clear();
            tbProdAmount.Clear();
            tbProdImage.Clear();
            tbProdPrice.Clear();
            cbCatalog.SelectedIndex = -1;
            cbSupplier.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
            cbImages.Items.Clear();
            Lib.ImageLoad__Null(picMain);
        }
    }
}