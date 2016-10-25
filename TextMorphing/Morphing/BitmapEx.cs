using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Morphing
{
    public unsafe static class BitmapEx
    {
        public static Color[][] GetColors(this Bitmap src)
        {
            Color[][] cs = new Color[src.Width][];

            BitmapData bd = src.LockBits(new Rectangle(Point.Empty, src.Size), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            byte* rgbs = (byte*)bd.Scan0;

            for (int x = 0; x < src.Width; x++)
            {
                cs[x] = new Color[src.Height];

                for (int y = 0; y < src.Height; y++)
                {
                    int idx = bd.Stride * y + x * 3;

                    cs[x][y] = Color.FromArgb(rgbs[idx + 2], rgbs[idx + 1], rgbs[idx]);
                }
            }

            src.UnlockBits(bd);

            return cs;
        }

        public static Bitmap Grayscale(this Bitmap src, float level)
        {
            var cm = new ColorMatrix(
                new float[][]
                {
                    new float[] { 0.299f, 0.299f, 0.299f, 0f, 0f },
                    new float[] { 0.587f, 0.587f, 0.587f, 0f, 0f },
                    new float[] { 0.114f, 0.114f, 0.114f, 0f, 0f },
                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { 0, 0, 0, 0, 1 },
                });

            var iAttr = new ImageAttributes();
            iAttr.SetColorMatrix(cm);
            iAttr.SetThreshold(level);

            var bmp = new Bitmap(src.Width, src.Height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(src, new Rectangle(Point.Empty, src.Size), 0, 0, src.Width, src.Height, GraphicsUnit.Pixel, iAttr);
            }

            return bmp;
        }
        
        public static byte[][] ToBit(this Bitmap src)
        {
            byte[][] bit = new byte[src.Width][];

            var gray = src.Grayscale(0.6f);
            var cs = gray.GetColors();

            for (int x = 0; x < src.Width; x++)
            {
                bit[x] = new byte[src.Height];

                for (int y = 0; y < src.Height; y++)
                {
                    if (cs[x][y].ToArgb() != -16777216)
                        bit[x][y] = 1;
                    else
                        bit[x][y] = 0;
                }
            }

            return bit;
        }
    }
}