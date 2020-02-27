using System.Drawing;

namespace MagicCube
{
    internal class Settings
    {
        internal static int LineSize { get; set; }
        internal static int BlockSize { get; set; }
        internal static Size ScreenSize { get; set; }

        internal static Color ScreenColor { get; set; }
        internal static Color LineColor { get; set; }
        internal static Color[] Colors { get; set; }

        private Settings() { }

        static Settings()
        {
            LineSize = 3;
            BlockSize = 60;
            ScreenSize = SetScreenSize();

            ScreenColor = Color.Black;
            LineColor = Color.FromArgb(127, 127, 127);
            Colors = SetColors();
        }

        private static Size SetScreenSize()
        {
            int width = 13 * LineSize + 14 * BlockSize;
            int height = 10 * LineSize + 11 * BlockSize;
            return new Size(width, height);
        }

        private static Color[] SetColors()
        {
            Color[] colors = new Color[6];
            colors[0] = Color.FromArgb(0, 0, 255);
            colors[1] = Color.FromArgb(255, 255, 0);
            colors[2] = Color.FromArgb(255, 0, 0);
            colors[3] = Color.FromArgb(255, 255, 255);
            colors[4] = Color.FromArgb(0, 255, 0);
            colors[5] = Color.FromArgb(255, 127, 0);
            return colors;
        }
    }
}
