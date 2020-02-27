using System.Drawing;

namespace MagicCube
{
    internal class Cube
    {
        private static Cube cube;

        private readonly Color[,,] block = new Color[6, 3, 3];

        private Cube()
        {
            Init();
        }

        internal static Cube GetCube()
        {
            if (cube == null)
                cube = new Cube();
            return cube;
        }

        internal void Init()
        {
            for (int z = 0; z < block.GetLength(0); z++)
            {
                for (int x = 0; x < block.GetLength(1); x++)
                {
                    for (int y = 0; y < block.GetLength(2); y++)
                    {
                        block[z, x, y] = Settings.Colors[z];
                    }
                }
            }
        }

        internal Color[,,] GetBlock()
        {
            return block;
        }
    }
}
