using System.ComponentModel;
using System.Windows.Forms;

namespace MagicCube
{
    public class Program : Form
    {
        private readonly IContainer components = null;
        private readonly PictureBox pictureBox = new PictureBox();

        private Program()
        {
            Text = "Magic Cube - AlbertBrook";
            ClientSize = Settings.ScreenSize;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Settings.ScreenColor;

            pictureBox.Size = Settings.ScreenSize;
            Controls.Add(pictureBox);

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

        internal PictureBox GetPictureBox()
        {
            return pictureBox;
        }
    }
}
