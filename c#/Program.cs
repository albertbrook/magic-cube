using System.ComponentModel;
using System.Windows.Forms;

namespace MagicCube
{
    public class Program : Form
    {
        private readonly IContainer components = null;

        private Program()
        {
            this.Text = "Magic Cube - AlbertBrook";
            this.ClientSize = Settings.ScreenSize;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Settings.ScreenColor;

            Functions.GetFunctions(this);
        }

        public static void Main()
        {
            Application.Run(new Program());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
