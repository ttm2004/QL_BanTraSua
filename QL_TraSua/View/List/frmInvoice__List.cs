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
    public partial class frmInvoice__List : Form
    {
        private List<string> listSelectRowFromDGV;
        private string code__selected;

        public frmInvoice__List()
        {
            InitializeComponent();
            load();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            code__selected = dgvList.RowCount != 0 ? dgvList.CurrentRow.Cells[1].Value.ToString() : null;
            if (string.IsNullOrEmpty(code__selected)) return;

            if (Temp.IsAdmin) return;

            btDelete.Enabled = Temp.User.Equals(new bInvoice().GetDetail(code__selected).UserID);
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(code__selected))
            {
                ShowMessagebox.Error("Chưa chọn đơn bán hàng!");
                return;
            }

            openForm(true, false);
        }

        private void dgvList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            dgvList.Rows.Cast<DataGridViewRow>().ToList().ForEach(i => i.MinimumHeight = 40);
            dgvList.AutoSizeColumnsMode = WindowState == FormWindowState.Maximized ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.None;
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

        private void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                openEdit();
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
            btAdd.Visible = !Temp.IsAdmin;
        }

        // tải danh sách dữ liệu
        private void listLoad()
        {
            try
            {
                setList();
                lblResult.Text = "Kết quả tìm thấy: " + new bInvoice().GetCount(tbSearch.Text.Trim(), dpFrom.Value, dpTo.Value, chbDate.Checked, Lib.ConvertIntFromPrice(tbPriceFrom), Lib.ConvertIntFromPrice(tbPriceTo), chbPrice.Checked).ToString();
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
            IEnumerable<Invoice> data = new bInvoice().GetList(tbSearch.Text.Trim(), dpFrom.Value, dpTo.Value, chbDate.Checked, Lib.ConvertIntFromPrice(tbPriceFrom), Lib.ConvertIntFromPrice(tbPriceTo), chbPrice.Checked);

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
                    new DataGridViewTextBoxCell { Value = i.InvoiceCode },
                    new DataGridViewTextBoxCell { Value = Lib.ConvertDateToString(i.Date) },
                    new DataGridViewTextBoxCell { Value = i.UserID },
                    new DataGridViewTextBoxCell { Value = i.User.Name },
                    new DataGridViewTextBoxCell { Value = i.CustomerPhone},
                    new DataGridViewTextBoxCell { Value = i.Customer.Name },
                    new DataGridViewTextBoxCell { Value = new bInvoiceDetail().GetQuantity(i.InvoiceCode) },
                    new DataGridViewTextBoxCell { Value = Lib.ConvertPrice(i.Total.ToString(), true) }
                }
            }).ToArray());
        }

        // xoá dữu liệu đã chọn
        private void deleteRows()
        {
            if (!eventCellValue(false)) return;

            if (ShowMessagebox.Question($"Bạn có muốn xoá đơn bán hàng {String.Join(",", listSelectRowFromDGV.ToArray())} không?") == DialogResult.No)
                return;

            var bak = new List<Invoice>(); // backup hoá đơn
            var bakDetail = new List<InvoiceDetail>(); // backup hoá đơn chi tiết
            var bakProd = new List<Product>(); // backup sản phẩm

            foreach (var i in listSelectRowFromDGV)
            {
                var tempListProd = new bInvoiceDetail().GetList(i); // lấy danh sách sản phẩm của hoá đơn.
                var tempBakDetail = new List<InvoiceDetail>();
                foreach (var e in tempListProd)
                {
                    bool rs = new bInvoiceDetail().Delete(e.InvoiceID, e.ProductID);

                    if (!rs)
                    {
                        rollbackInvoices(bak, bakDetail, bakProd);
                        ShowMessagebox.Error("Không thể xoá đơn nhập chi tiết!");
                        return;
                    }

                    tempBakDetail.Add(e);
                    bakDetail.Add(e);
                }

                foreach (var e in tempBakDetail)
                {
                    var tempProd = new bProduct().GetDetail(e.ProductID);
                    bool rs = new bProduct().UpdateAmount(e.ProductID, e.Quantity, true);

                    if (!rs)
                    {
                        rollbackInvoices(bak, bakDetail, bakProd);
                        ShowMessagebox.Error("Không thể xoá sản phẩm!");
                        return;
                    }

                    tempProd.Amount = e.Quantity;
                    bakProd.Add(tempProd);
                }

                var tempInvoice = new bInvoice().GetDetail(i);
                bool result = new bInvoice().Delete(i);

                if (!result)
                {
                    rollbackInvoices(bak, bakDetail, bakProd);
                    ShowMessagebox.Error("Không thể xoá đơn nhập!");
                    return;
                }

                bak.Add(tempInvoice);
            }

            listLoad();
        }

        // khôi phục lại dữ liệu khi xoá không thành công
        private void rollbackInvoices(List<Invoice> imports, List<InvoiceDetail> importDetails, List<Product> products)
        {
            if (products.Count != 0)
                products.ForEach(x => new bProduct().UpdateAmount(x.ProductCode, x.Amount, false));

            if (imports.Count != 0)
                imports.ForEach(x => new bInvoice().Add(x));

            if (importDetails.Count != 0)
                importDetails.ForEach(x => new bInvoiceDetail().Add(x));
        }

        // mở form chi tiết ở dạng xem chi tiết
        private void openDetail()
        {
            if (!eventCellValue(true)) return;

            openForm(true, false);
        }

        // mở form chi tiết ở dạng chỉnh sửa
        private void openEdit()
        {
            if (!eventCellValue(true)) return;

            openForm(false, false);
        }

        // mở form chi tiết
        // isView true hoặc false để hiển thị ở dạng xem chi tiết, isAdd để hiển thị ở dạng thêm mới
        private void openForm(bool isView, bool isAdd)
        {
            if (isAdd)
            {
                using (var frm = new frmInvoice__Detail(isAdd))
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                        listLoad();
                }
                return;
            }

            using (var frm = new frmInvoice__Detail(code__selected, isView))
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