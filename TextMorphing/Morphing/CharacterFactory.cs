using System.Drawing;
using System.Windows.Forms;

namespace Morphing
{
    public static class CharacterFactory
    {
        public static Bitmap ToBitmap(string s, Font font = null)
        {
            Font f = font ?? new Font("맑은고딕", 100, FontStyle.Bold);

            Size sz = TextRenderer.MeasureText(s, f);
            Bitmap bmp = new Bitmap(sz.Width + 50, sz.Height + 50);

            using (var g = Graphics.FromImage(bmp))
                g.DrawString(s, f, Brushes.White, 0, 0);

            f.Dispose();

            return bmp;
        }
    }
}