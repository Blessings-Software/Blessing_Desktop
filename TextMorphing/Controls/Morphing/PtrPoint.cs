using System.Drawing;

namespace TextMorphing.Controls
{
    public class PtrPoint
    {
        public float X { get; set; }
        public float Y { get; set; }

        public PtrPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public PointF ToPointF()
        {
            return new PointF(X, Y);
        }

        public PointF ToPoint()
        {
            return new Point((int)X, (int)Y);
        }
    }
}
