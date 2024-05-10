using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShopSimple.Library
{
    public class Lib
    {
        // hàm chuyển đổi tên các nút khi mở form để thêm hoặc xem hoặc chỉnh sửa.
        public static void ChangeTextButtonCURD(bool isAdd, bool isViewOrEdit, Button btPrimary, Button btDanger)
        {
            btPrimary.Text = isAdd ? TextCommon.Save : (isViewOrEdit ? TextCommon.Edit : TextCommon.Save);
            btDanger.Text = isAdd ? TextCommon.Cancel : (isViewOrEdit ? TextCommon.Delete : TextCommon.Cancel);
        }

        // hàm kiểm tra các textbox nhập liệu không trống, nếu trống trả ra true.
        // panel control (panel) chứa các textbox
        public static bool CheckInputNoEmpty(Control panel)
        {
            return panel.Controls.OfType<TextBox>().Count(i => !string.IsNullOrEmpty(i.Text.Trim())) != 0;
        }

        public static bool CheckTextBoxEmpty(Control panel)
        {
            int count = 0;
            panel.Controls.OfType<TextBox>().ToList().ForEach(i => count += string.IsNullOrEmpty(i.Text.Trim()) ? 1 : 0);
            return count == 0;
        }

        public static bool CheckControlEmpty(Control panel)
        {
            int count = 0;
            panel.Controls.OfType<TextBox>().ToList().ForEach(i => count += string.IsNullOrEmpty(i.Text.Trim()) ? 1 : 0);
            panel.Controls.OfType<ComboBox>().ToList().ForEach(i => count += string.IsNullOrEmpty(i.Text.Trim()) ? 1 : 0);
            return count == 0;
        }

        // Hàm tự động chuyển trạng thái cho phép thao tác hoặc không cho phép
        public static void ReadOnlyControl(Control parent, bool isReadOnly)
        {
            var tbs = parent.Controls.OfType<TextBox>();
            var cbs = parent.Controls.OfType<ComboBox>();
            var chbs = parent.Controls.OfType<CheckBox>();

            tbs.ToList().ForEach(i => i.ReadOnly = isReadOnly);
            cbs.ToList().ForEach(i => i.Enabled = !isReadOnly);
            chbs.ToList().ForEach(i => i.Enabled = !isReadOnly);
        }

        // Khôi phục lại control
        public static void ClearControl(Control panel, bool isTrue)
        {
            panel.Controls.OfType<TextBox>().ToList().ForEach(i => i.Clear());
            panel.Controls.OfType<ComboBox>().ToList().ForEach(i => i.SelectedIndex = -1);
            panel.Controls.OfType<CheckBox>().ToList().ForEach(i => i.Checked = isTrue);
        }

        // hàm lấy giá trị đã chọn từ danh sách
        public static List<string> GetValueFormDataGridView(DataGridView dgv, int indexCell)
        {
            return dgv.SelectedRows.Cast<DataGridViewRow>().Select(i => i.Cells[indexCell].Value.ToString()).ToList();
        }

        // hàm kiểm tra số dòng đã chọn trên danh sách, sử dụng khi bắt lỗi chọn nhiều dòng hoặc không chọn dòng nào trên danh sách khi thực hiện các chức năng như sửa, chi tiết và xoá.
        public static bool CheckRow__SelectDataGridView(bool isOneRow, List<string> list, string code, string title)
        {
            if (string.IsNullOrEmpty(code) || !list.Any())
            {
                ShowMessagebox.Error($"Chưa chọn {title}!");
                return false;
            }

            if (isOneRow && list.Count > 1)
            {
                ShowMessagebox.Error("Chỉ có thể chọn một dòng!");
                return false;
            }

            return true;
        }

        // Hàm thay đổi định dạng tiền, Nếu định dạng không hoạt động thì chuyển Regional format thành Vietnamese, hoặc đổi price.Replace(".", "") => price.Replace(",", "") nếu như Regional là Eng US
        public static string ConvertPrice(string price, bool isFormat)
        {
            try
            {
                if (string.IsNullOrEmpty(price)) return "";
                return isFormat ? String.Format("{0:#,####}", long.Parse(price)) : price.Replace(".", "");
            }
            catch
            {
                return price;
            }
        }

        // Hàm lấy dữ liệu từ định dạng tiền
        public static int ConvertIntFromPrice(TextBox tb)
        {
            var t = tb.Text.Trim();

            if (string.IsNullOrEmpty(t)) return 0;
            return int.Parse(ConvertPrice(t, false));
        }

        // định dạng hiển thị ngày cho textbox
        public static string ConvertDateToString(DateTime date)
        {
            return $"{date.Day.ToString("d2")}/{date.Month.ToString("d2")}/{date.Year} {date.Hour.ToString("d2")}:{date.Minute.ToString("d2")}:{date.Second.ToString("d2")}";
        }

        #region Image

        // lấy đường dẫn đến thư mục .exe của chương trình
        private static string CurrentPath()
        {
            return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        }

        // tạo thư mục chứa hình ảnh
        public static void CreateImageFolder()
        {
            Directory.CreateDirectory(ImagesFolderPath());
        }

        // lấy đường dẫn đến thư mục chứa hình ảnh cho sản phẩm
        public static string ImagesFolderPath()
        {
            return Path.Combine(CurrentPath(), $"Products Image");
        }

        // lấy đường dẫn đến file hình ảnh
        public static string GetImage(string imageName)
        {
            return Path.Combine(ImagesFolderPath(), imageName.Trim());
        }

        public static void ImageDelete(string imageName)
        {
            var path = GetImage(imageName);
            if (File.Exists(path)) File.Delete(path);
        }

        public static void ImageImport(string imageName, string sourcePath)
        {
            if (!File.Exists(ImagesFolderPath())) CreateImageFolder();

            if (File.Exists(GetImage(imageName)))
            {
                if (ShowMessagebox.Question($"Đã tồn tại \'{imageName}\', bạn có muốn thay thế không?") == DialogResult.No)
                    return;

                File.Delete(GetImage(imageName));
            }

            File.Copy(Path.Combine(sourcePath, imageName), GetImage(imageName), true);
        }

        // hiển thị hình ảnh lên PictureBox, với PictureBox là control hiển thị ảnh
        public static void ImageLoad(string imageName, PictureBox picture)
        {
            if (string.IsNullOrEmpty(imageName) || !File.Exists(GetImage(imageName)))
            {
                ImageLoad__Null(picture);
                return;
            }
            using (FileStream stream = new FileStream(GetImage(imageName), FileMode.Open, FileAccess.Read))
            {
                picture.Image = Image.FromStream(stream);
                stream.Dispose();
            }
        }

        // hiển thị hình ảnh lên PictureBox, với PictureBox là control hiển thị ảnh
        public static void ImageLoadOneImage(string imageName, PictureBox picture)
        {
            imageName = GetImage__First(imageName);
            if (string.IsNullOrEmpty(imageName) || !File.Exists(GetImage(imageName)))
            {
                ImageLoad__Null(picture);
                return;
            }

            using (FileStream stream = new FileStream(GetImage(imageName), FileMode.Open, FileAccess.Read))
            {
                picture.Image = Image.FromStream(stream);
                stream.Dispose();
            }
        }

        // hiển thị hình ảnh lên PictureBox, với PictureBox là control hiển thị ảnh
        public static void ImageLoad(string imageName, string desSource, PictureBox picture)
        {
            var path = Path.Combine(desSource, imageName);
            if (string.IsNullOrEmpty(imageName) || !File.Exists(path))
            {
                ImageLoad__Null(picture);
                return;
            }
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                picture.Image = Image.FromStream(stream);
                stream.Dispose();
            }
        }

        // Hiển thị hình ảnh có sẵn khi không tìm thấy hình ảnh cho sản phẩm
        public static void ImageLoad__Null(PictureBox picture)
        {
            picture.Image = Properties.Resources.noImages;
        }

        // hàm hiển thị hình ảnh lên danh sách.
        public static Image ImageLoad__ForList(string imageName)
        {
            imageName = GetImage__First(imageName);
            var path = GetImage(imageName);
            return (string.IsNullOrEmpty(imageName) || !File.Exists(path)) ? new Bitmap(Properties.Resources.noImages).GetThumbnailImage(100, 100, null, IntPtr.Zero) : new Bitmap(GetImage(imageName)).GetThumbnailImage(100, 100, null, IntPtr.Zero);
        }

        // hàm hiển thị hình ảnh lên danh sách.
        public static Image ImageLoad__ForList(string imageName, string desPath)
        {
            imageName = GetImage__First(imageName);
            var path = Path.Combine(desPath, imageName);
            return (string.IsNullOrEmpty(imageName) || !File.Exists(path)) ? new Bitmap(Properties.Resources.noImages).GetThumbnailImage(100, 100, null, IntPtr.Zero) : new Bitmap(path).GetThumbnailImage(100, 100, null, IntPtr.Zero);
        }

        // Tách các hình ảnh trong chuỗi thành một từng hình riêng biệt, VD: img1.png, img2.png => array ["img1.png", "img2.png"]
        public static string[] SplitImage(string strImage) => strImage.Split(',').Select(x => x.Trim()).ToArray();

        // Lấy hình đâu tiên trong chuỗi hình ảnh
        public static string GetImage__First(string strImage) => SplitImage(strImage)[0];

        #endregion Image

        #region Key

        // chuyển thời gian thành ký tự kết hợp với ký tự đầu tiên của key
        // chỉ lấy ngày
        private static string ConstantDate(string firstKey)
        {
            string[] partsDay = System.DateTime.Now.ToString("yyyy/MM/dd").Split('/');
            return $"{firstKey}{partsDay[0]}{partsDay[1]}{partsDay[2]}";
        }

        // chuyển thời gian thành ký tự kết hợp với ký tự đầu tiên của key
        // lấy ngày và thời gian
        private static string ConstantDateFull(string firstKey)
        {
            string[] partsDay = System.DateTime.Now.ToString("yyyy/MM/dd").Split('/');
            string[] partsTime = System.DateTime.Now.ToString("HH:mm:ss").Split(':');
            return $"{firstKey}{partsDay[0]}{partsDay[1]}{partsDay[2]}{partsTime[0]}{partsTime[1]}{partsTime[2]}";
        }

        // tạo mã tự động
        public static string CreateKey(string key, bool isFullDateTime)
        {
            return isFullDateTime ? ConstantDateFull(key) : ConstantDate(key);
        }

        #endregion Key
    }
}