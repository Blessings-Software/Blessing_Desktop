using System;
using System.Drawing;

namespace Morphing
{
    public static class Bit2D
    {
        public static byte[][] Copy(this byte[][] bit)
        {
            byte[][] copy = new byte[bit.Length][];

            for (int x = 0; x < bit.Length; x++)
            {
                copy[x] = new byte[bit[0].Length];

                Array.Copy(bit[x], copy[x], copy[x].Length);
            }

            return copy;
        }

        public static byte[][] GetOutline(this byte[][] bit)
        {
            byte[][] buffer = new byte[bit.Length][];

            for (int x = 0; x < bit.Length; x++)
            {
                buffer[x] = new byte[bit[0].Length];
                Array.Copy(bit[x], buffer[x], buffer[x].Length);

                for (int y = 0; y < bit[0].Length; y++)
                {
                    int d = 0;

                    if (bit[x][y] > 0)
                    {
                        if (x > 0) d += bit[x - 1][y];
                        if (y > 0) d += bit[x][y - 1];
                        if (x < bit.Length - 1) d += bit[x + 1][y];
                        if (y < bit[0].Length - 1) d += bit[x][y + 1];

                        if (d == 4) buffer[x][y] = 0;
                    }
                }
            }

            return buffer;
        }

        public static Bitmap BitToBitmap(this byte[][] bit, Color c)
        {
            var bmp = new Bitmap(bit.Length, bit[0].Length);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (bit[x][y] != 0)
                    {
                        bmp.SetPixel(x, y, c);
                    }
                }
            }

            return bmp;
        }
    }
}
