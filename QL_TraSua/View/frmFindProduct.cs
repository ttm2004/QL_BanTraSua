using ShopSimple.Controller;
using ShopSimple.Library;
using ShopSimple.Model;
using ShopSimple.View.Detail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ShopSimple.View
{
    public partial class frmFindProduct : Form
    {
        public SendProductChoice send;
        private string code__selected;

        public frmFindProduct(SendProductChoice sender)
        {
            InitializeComponent();
            this.send = sender;
            load();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            code__selected = dgvList.RowCount != 0 ? dgvList.CurrentRow.Cells[2].Value.ToString() : null;
            lblChoice.Text = $"{lblChoice.Tag} {code__selected}";
        }

        private void dgvList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            dgvList.Rows.Cast<DataGridViewRow>().ToList().ForEach(i => i.MinimumHeight = 100);
            dgvList.AutoSizeColumnsMode = WindowState == FormWindowState.Maximized ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.None;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            code__selected = dgvList.RowCount != 0 ? dgvList.CurrentRow.Cells[2].Value.ToString() : null;

            if (string.IsNullOrEmpty(code__selected))
            {
                ShowMessagebox.Error("Chưa chọn sản phẩm!");
                return;
            }

            this.send(code__selected);
            this.Close();
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            code__selected = dgvList.RowCount != 0 ? dgvList.CurrentRow.Cells[2].Value.ToString() : null;
            lblChoice.Text = $"{lblChoice.Tag} {code__selected}";
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

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btChoice_Click(object sender, EventArgs e)
        {
            try
            {
                this.send(code__selected);
                this.Close();
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
        }

        // tải danh sách dữ liệu
        private void listLoad()
        {
            try
            {
                setList();
                lblResult.Text = "Kết quả tìm thấy: " + new bProduct().GetCount(tbSearch.Text.Trim()).ToString();
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
            IEnumerable<Product> data = new bProduct().GetList(tbSearch.Text.Trim());

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
                    new DataGridViewImageCell { Value = Lib.ImageLoad__ForList(i.Image) },
                    new DataGridViewTextBoxCell { Value = i.ProductCode },
                    new DataGridViewTextBoxCell { Value = i.Name },
                    new DataGridViewTextBoxCell { Value = i.Catalog.Name },
                    new DataGridViewTextBoxCell { Value = i.Supplier.Name },
                    new DataGridViewTextBoxCell { Value = i.Amount },
                    new DataGridViewTextBoxCell { Value = Lib.ConvertPrice(i.Price.ToString(), true) }
                }
            }).ToArray());
        }
    }
}