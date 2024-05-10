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
    public partial class frmCatalog__List : Form
    {
        private List<string> listSelectRowFromDGV;
        private string code__selected;

        public frmCatalog__List()
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
                ShowMessagebox.Error("Chưa chọn loại sản phẩm!");
                return;
            }

            openForm(true, false);
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            code__selected = dgvList.RowCount != 0 ? dgvList.CurrentRow.Cells[1].Value.ToString() : null;
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
            btAdd.Visible = btEdit.Visible = btDelete.Visible = Temp.IsAdmin;
        }

        // tải danh sách dữ liệu
        private void listLoad()
        {
            try
            {
                setList();
                lblResult.Text = "Kết quả tìm thấy: " + new bCatalog().GetCount(tbSearch.Text.Trim()).ToString();
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
            IEnumerable<Catalog> data = new bCatalog().GetList(tbSearch.Text.Trim());

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
                    new DataGridViewTextBoxCell { Value = i.CatalogCode },
                    new DataGridViewTextBoxCell { Value = i.Name }
                }
            }).ToArray());
        }

        // xoá dữu liệu đã chọn
        private void deleteRows()
        {
            if (!eventCellValue(false)) return;

            if (ShowMessagebox.Question($"Bạn có muốn xoá loại sản phẩm {String.Join(",", listSelectRowFromDGV.ToArray())} không?") == DialogResult.No)
                return;

            List<Catalog> bak = new List<Catalog>();

            foreach (var i in listSelectRowFromDGV)
            {
                bool rs = new bCatalog().Delete(i);

                if (!rs)
                {
                    bak.ForEach(e => new bCatalog().Add(e));
                    ShowMessagebox.Error($"Không thể xoá {i}: {new bCatalog().GetDetail(i).Name}!");
                    return;
                }

                bak.Add(new bCatalog().GetDetail(i));
            }
            listLoad();
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
                using (var frm = new frmCatalog__Detail(isAdd))
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.Yes)
                        listLoad();
                }
                return;
            }

            using (var frm = new frmCatalog__Detail(code__selected, isView))
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