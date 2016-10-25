using SharpDX.Mathematics.Interop;
using System.Drawing;

namespace St2D.Utils
{
    public static class ColorConverter
    {
        public static RawColor4 ToColor4(this Color c)
        {
            return new RawColor4(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f);
        }
    }
}