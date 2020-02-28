using System.Drawing;
using System.Windows.Forms;

namespace MagicCube
{
    internal class Functions
    {
        private static Functions functions;

        private readonly Program program;
        private readonly Cube cube;
        private readonly Actions actions;

        private readonly PictureBox pic;

        private Functions(Program program)
        {
            this.program = program;
            cube = Cube.GetCube();
            actions = Actions.GetActions();

            pic = this.program.GetPictureBox();
            Paint();
            this.program.KeyDown += new KeyEventHandler(Event);
        }

        internal static Functions GetFunctions(Program program)
        {
            if (functions == null)
                functions = new Functions(program);
            return functions;
        }

        private void Paint()
        {
            Bitmap bitmap = new Bitmap(Settings.ScreenSize.Width, Settings.ScreenSize.Height);
            Graphics g = Graphics.FromImage(bitmap);
            int z = 0;
            for (int i = 0; i < 12; i += 3)
                for (int j = 0; j < 9; j += 3)
                {
                    if (i == 3 || j == 3)
                    {
                        DrawPlane(g, i, j);
                        FillPlane(g, i, j, z++);
                    }
                }
            pic.Image = bitmap;
        }

        private void DrawPlane(Graphics g, int i, int j)
        {
            int location = Settings.LineSize / 2 + Settings.BlockSize;
            int size = Settings.LineSize + Settings.BlockSize;
            Pen p = new Pen(Settings.LineColor, Settings.LineSize);
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    g.DrawRectangle(p, location + (i + x) * size, location + (j + y) * size, size, size);
        }

        private void FillPlane(Graphics g, int i, int j, int z)
        {
            int size = Settings.LineSize + Settings.BlockSize;
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                {
                    SolidBrush b = new SolidBrush(cube.GetBlock()[z, x, y]);
                    g.FillRectangle(b, (i + y + 1) * size, (j + x + 1) * size, Settings.BlockSize, Settings.BlockSize);
                }
        }

        private void Event(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.J:
                    actions.UpRotate();
                    break;
                case Keys.D:
                    actions.DownRotate();
                    break;
                case Keys.S:
                    actions.LeftRotate();
                    break;
                case Keys.I:
                    actions.RightRotate();
                    break;
                case Keys.T:
                    actions.FrontRotate();
                    break;
                case Keys.F:
                    actions.BackRotate();
                    break;
                case Keys.Z:
                    actions.XRotate();
                    break;
                case Keys.X:
                    actions.YRotate();
                    break;
                case Keys.C:
                    actions.ZRotate();
                    break;
                case Keys.L:
                    for (int i = 0; i < 3; i++)
                        actions.UpRotate();
                    break;
                case Keys.A:
                    for (int i = 0; i < 3; i++)
                        actions.DownRotate();
                    break;
                case Keys.W:
                    for (int i = 0; i < 3; i++)
                        actions.LeftRotate();
                    break;
                case Keys.K:
                    for (int i = 0; i < 3; i++)
                        actions.RightRotate();
                    break;
                case Keys.G:
                    for (int i = 0; i < 3; i++)
                        actions.FrontRotate();
                    break;
                case Keys.H:
                    for (int i = 0; i < 3; i++)
                        actions.BackRotate();
                    break;
                case Keys.B:
                    for (int i = 0; i < 3; i++)
                        actions.XRotate();
                    break;
                case Keys.N:
                    for (int i = 0; i < 3; i++)
                        actions.YRotate();
                    break;
                case Keys.M:
                    for (int i = 0; i < 3; i++)
                        actions.ZRotate();
                    break;
                case Keys.D0:
                    cube.Init();
                    break;
            }
            Paint();
        }
    }
}
