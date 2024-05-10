using System;
using System.Windows.Forms;

namespace ShopSimple.Library
{
    public class ShowMessagebox
    {
        private static string Title = "Thông báo";

        public static void Error(string text)
        {
            MessageBox.Show(text, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Exception(Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Question(string text)
        {
            return MessageBox.Show(text, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult Susscess(string text)
        {
            return MessageBox.Show(text, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}