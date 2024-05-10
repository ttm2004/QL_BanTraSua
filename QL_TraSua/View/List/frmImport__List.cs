using ShopSimple.Controller;
using ShopSimple.Library;
using ShopSimple.Model;
using ShopSimple.View.Detail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ShopSimple.View.List
{
    public partial class frmImport__List : Form
    {
        private List<string> listSelectRowFromDGV;
        private string code__selected;

        public frmImport__List()
        {
            InitializeComponent();
            load();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            code__selected = dgvList.RowCount != 0 ? dgvList.CurrentRow.Cells[1].Value.ToString() : null;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(code__selected))
            {
                ShowMessagebox.Error("Chưa chọn đơn nhập hàng!");
                return;
            }

            openForm(true, false);
        }

        private void dgvList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            dgvList.Rows.Cast<DataGridViewRow>().ToList().ForEach(i => i.MinimumHeight = 40);
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            code__selected = dgvList.RowCount != 0 ? dgvList.CurrentRow.Cells[1].Value.ToString() : null;
        }

        private void chbPrice_CheckedChanged(object sender, EventArgs e)
        {
            tbPriceFrom.Enabled = tbPriceTo.Enabled = chbPrice.Checked;
        }

        private void chbDate_CheckedChanged(object sender, EventArgs e)
        {
            dpFrom.Enabled = dpTo.Enabled = chbDate.Checked;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            try
            {
                Lib.ClearControl(gbSearch, false); // gọi hàm khổi phục control
                listLoad();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                listLoad();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btView_Click(object sender, EventArgs e)
        {
            try
            {
                openDetail();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                openForm(false, true);
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvList.Rows.Count < 1)
                {
                    ShowMessagebox.Error("Không có dữ liệu để xoá!");
                    return;
                }

                deleteRows();
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
                btClear.PerformClick();
            }
            catch (Exception ex)
            {
                ShowMessagebox.Exception(ex);
            }
        }

        // function
        private void load()
        {
            listLoad();
            eventRole();
        }

        // kiểm tra phân quyền để hiển thị chức năng đúng với phân quyền người dùng.
        private void eventRole()
        {
            btAdd.Visible = btDelete.Visible = Temp.IsAdmin;
        }

        // tải danh sách dữ liệu
        private void listLoad()
        {
            try
            {
                setList();
                lblResult.Text = "Kết quả tìm thấy: " + new bImport().GetCount(tbSearch.Text.Trim(), dpFrom.Value, dpTo.Value, chbDate.Checked, Lib.ConvertIntFromPrice(tbPriceFrom), Lib.ConvertIntFromPrice(tbPriceTo), chbPrice.Checked).ToString();
            }
            catch (Exception ex)
            {
                dgvList.DataSource = null;
                ShowMessagebox.Exception(ex);
            }
        }

        // gán dữ liệu vào datagridview
        private void setList()
        {
            IEnumerable<Import> data = new bImport().GetList(tbSearch.Text.Trim(), dpFrom.Value, dpTo.Value, chbDate.Checked, Lib.ConvertIntFromPrice(tbPriceFrom), Lib.ConvertIntFromPrice(tbPriceTo), chbPrice.Checked);

            if (data == null)
            {
                ShowMessagebox.Error("Không có dữ liệu!");
                return;
            }

            dgvList.Rows.Clear();
            dgvList.Rows.AddRange(data.Select((i, count) => new DataGridViewRow
            {
                Cells =
                {
                    new DataGridViewTextBoxCell { Value = count + 1 },
                    new DataGridViewTextBoxCell { Value = i.ImportCode },
                    new DataGridViewTextBoxCell { Value = Lib.ConvertDateToString(i.Date) },
                    new DataGridViewTextBoxCell { Value = i.UserID },
                    new DataGridViewTextBoxCell { Value = i.Admin.Name },
                    new DataGridViewTextBoxCell { Value = new bImportDetail().GetQuantity(i.ImportCode) },
                    new DataGridViewTextBoxCell { Value = Lib.ConvertPrice(i.Total.ToString(), true) }
                }
            }).ToArray());
        }

        // xoá dữu liệu đã chọn
        private void deleteRows()
        {
            if (!eventCellValue(false)) return;

            if (ShowMessagebox.Question($"Bạn có muốn xoá đơn nhập hàng [{String.Join(",", listSelectRowFromDGV.ToArray())}] không?") == DialogResult.No)
                return;

            var bak = new List<Import>(); // backup hoá đơn
            var bakDetail = new List<ImportDetail>(); // backup hoá đơn chi tiết
            var bakProd = new List<Product>(); // backup sản phẩm
            var strImgDelete = new List<string>();

            foreach (var i in listSelectRowFromDGV)
            {
                var tempListProd = new bImportDetail().GetList(i); // lấy danh sách sản phẩm của hoá đơn.
                var tempBakDetail = new List<ImportDetail>();
                int countExists = 0;

                tempListProd.ToList().ForEach(e => countExists += new bInvoiceDetail().CheckExistsProduct(e.ProductID) ? 1 : 0);

                if (countExists > 0)
                {
                    ShowMessagebox.Error($"Không thể xoá đơn nhập hàng do có {countExists} sản phẩm đã bán trong đơn nhập hàng này.");
                    return;
                }

                foreach (var e in tempListProd)
                {
                    bool rs = new bImportDetail().Delete(e.ImportID, e.ProductID);

                    if (!rs)
                    {
                        rollbackImports(bak, bakDetail, bakProd);
                        ShowMessagebox.Error("Không thể xoá đơn nhập chi tiết!");
                        return;
                    }
                    tempBakDetail.Add(e);
                    bakDetail.Add(e);
                }

                foreach (var e in tempBakDetail)
                {
                    var tempProd = new bProduct().GetDetail(e.ProductID);
                    bool rs = new bProduct().Delete(e.ProductID);

                    if (!rs)
                    {
                        rollbackImports(bak, bakDetail, bakProd);
                        ShowMessagebox.Error("Không thể xoá sản phẩm!");
                        return;
                    }

                    bakProd.Add(tempProd);
                    strImgDelete.Add(bakProd.FirstOrDefault(x => x.ProductCode == e.ProductID).Image.ToString());
                }

                var tempInvoice = new bImport().GetDetail(i);
                bool result = new bImport().Delete(i);

                if (!result)
                {
                    rollbackImports(bak, bakDetail, bakProd);
                    ShowMessagebox.Error("Không thể xoá đơn nhập!");
                    return;
                }

                bak.Add(tempInvoice);
            }

            var listImageNotDelete = new List<string>();
            foreach (var i in strImgDelete)
            {
                string[] imgs;

                try
                {
                    imgs = i.Split(',');
                }
                catch
                {
                    imgs = new string[] { i };
                }

                foreach (var e in imgs)
                {
                    try
                    {
                        Lib.ImageDelete(e.Trim());
                    }
                    catch
                    {
                        listImageNotDelete.Add(e.Trim());
                        break;
                    }
                }
            }

            if (listImageNotDelete.Count > 0)
                ShowMessagebox.Error($"Không thể xoá các hình ảnh [{String.Join(", ", listImageNotDelete.ToArray())}]!");

            listLoad();
        }

        // khôi phục lại dữ liệu khi xoá không thành công
        private void rollbackImports(List<Import> imports, List<ImportDetail> importDetails, List<Product> products)
        {
            if (products.Count != 0)
                products.ForEach(x => new bProduct().Add(x));

            if (imports.Count != 0)
                imports.ForEach(x => new bImport().Add(x));

            if (importDetails.Count != 0)
                importDetails.ForEach(x => new bImportDetail().Add(x));
        }

        // mở form chi tiết ở dạng xem chi tiết
        private void openDetail()
        {
            if (!eventCellValue(true)) return;

            openForm(true, false);
        }

        // mở form chi tiết
        // isView true hoặc false để hiển thị ở dạng xem chi tiết, isAdd để hiển thị ở dạng thêm mới
        private void openForm(bool isView, bool isAdd)
        {
            if (isAdd)
            {
                using (var frm = new frmImport__Detail(isAdd))
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                        listLoad();
                }
                return;
            }

            using (var frm = new frmImport__Detail(code__selected, isView))
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Yes)
                    listLoad();
            }
        }

        // kiểm tra tính trạng khi chọn dữ liệu
        private bool eventCellValue(bool isOneRow)
        {
            // gán mã đã chọn vào biến
            listSelectRowFromDGV = Lib.GetValueFormDataGridView(dgvList, 1);
            // trả ra true hoặc save với từng điều kiện yêu cầu
            return Lib.CheckRow__SelectDataGridView(isOneRow, listSelectRowFromDGV, code__selected, "Tình Trạng");
        }
    }
}