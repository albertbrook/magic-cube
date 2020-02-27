using System.Drawing;

namespace MagicCube
{
    internal class Actions
    {
        private static Actions actions;

        private readonly Color[,,] block;

        private Actions()
        {
            this.block = Cube.GetCube().GetBlock();
        }

        internal static Actions GetActions()
        {
            if (actions == null)
                actions = new Actions();
            return actions;
        }

        internal void UpRotate()
        {
            for (int i = 0; i < 3; i++)
            {
                ExchangeBlock(new int[,] { { 2, 0, i }, { 4, 0, i }, { 5, 0, i }, { 0, 0, i } });
            }
            Clockwise(1);
        }

        internal void DownRotate()
        {
            for (int i = 0; i < 3; i++)
                ExchangeBlock(new int[,] { { 2, 2, i }, { 0, 2, i }, { 5, 2, i }, { 4, 2, i } });
            Clockwise(3);
        }

        internal void LeftRotate()
        {
            for (int i = 0; i < 3; i++)
                ExchangeBlock(new int[,] { { 2, i, 0 }, { 1, i, 0 }, { 5, 2 - i, 2 }, { 3, i, 0 } });
            Clockwise(0);
        }

        internal void RightRotate()
        {
            for (int i = 0; i < 3; i++)
                ExchangeBlock(new int[,] { { 2, i, 2 }, { 3, i, 2 }, { 5, 2 - i, 0 }, { 1, i, 2 } });
            Clockwise(4);
        }

        internal void FrontRotate()
        {
            for (int i = 0; i < 3; i++)
                ExchangeBlock(new int[,] { { 1, 2, i }, { 0, 2 - i, 2 }, { 3, 0, 2 - i }, { 4, i, 0 } });
            Clockwise(2);
        }

        internal void BackRotate()
        {
            for (int i = 0; i < 3; i++)
                ExchangeBlock(new int[,] { { 1, 0, i }, { 4, i, 2 }, { 3, 2, 2 - i }, { 0, 2 - i, 0 } });
            Clockwise(5);
        }

        internal void XRotate()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    ExchangeBlock(new int[,] { { 2, i, j }, { 3, i, j }, { 5, 2 - i, 2 - j }, { 1, i, j } });
                Clockwise(0);
            }
            Clockwise(4);
        }

        internal void YRotate()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    ExchangeBlock(new int[,] { { 2, i, j }, { 4, i, j }, { 5, i, j }, { 0, i, j } });
                Clockwise(3);
            }
            Clockwise(1);
        }

        internal void ZRotate()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    ExchangeBlock(new int[,] { { 1, i, j }, { 0, 2 - j, i }, { 3, 2 - i, 2 - j }, { 4, j, 2 - i } });
                Clockwise(5);
            }
            Clockwise(2);
        }

        private void Clockwise(int z)
        {
            ExchangeBlock(new int[,] { { z, 0, 0 }, { z, 2, 0 }, { z, 2, 2 }, { z, 0, 2 } });
            ExchangeBlock(new int[,] { { z, 0, 1 }, { z, 1, 0 }, { z, 2, 1 }, { z, 1, 2 } });
        }

        private void ExchangeBlock(int[,] iS)
        {
            for (int i = 0; i < iS.GetLength(0) - 1; i++)
            {
                Color temp = block[iS[i, 0], iS[i, 1], iS[i, 2]];
                block[iS[i, 0], iS[i, 1], iS[i, 2]] = block[iS[i + 1, 0], iS[i + 1, 1], iS[i + 1, 2]];
                block[iS[i + 1, 0], iS[i + 1, 1], iS[i + 1, 2]] = temp;
            }
        }
    }
}
