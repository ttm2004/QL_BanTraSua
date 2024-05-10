using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ShopSimple.View
{
    public partial class frmViewImage : Form
    {
        public frmViewImage(string path)
        {
            InitializeComponent();
            setImage(path);
            this.Text = $"{this.Tag}: {Path.GetFileName(path)}";
        }

        // hhiener thị hình ảnh
        private void setImage(string path)
        {
            if (File.Exists(path)) picMain.Image = Image.FromFile(path);
            else picMain.Image = Properties.Resources.noImages;
        }
    }
}