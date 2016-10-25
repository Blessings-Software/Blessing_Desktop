using d2 = SharpDX.Direct2D1;
using s = SharpDX;

using St2D.Utils;

using System;
using System.Drawing;

namespace St2D.Components
{
    public class Line : UIScene
    {
        public s.Vector2 Point1 { get; set; }
        public s.Vector2 Point2 { get; set; }
        public float Width { get; set; } = 1f;

        public Color Stroke
        {
            get { return _stroke; }
            set { _stroke = value; isUpdated = true; }
        }
        public d2.StrokeStyleProperties StrokeStyle
        {
            get { return _strokeStyleProp; }
            set { _strokeStyleProp = value; isUpdated = true; }
        }

        private Color _stroke = Color.Black;
        private d2.StrokeStyleProperties _strokeStyleProp;
        private bool isUpdated = false;

        protected d2.SolidColorBrush strokeBrush;
        protected d2.StrokeStyle strokeStyle;

        public Line(Renderer renderer) : base(renderer)
        {
            Update(true);
        }

        private void Update(bool forceUpdate = false)
        {
            if (isUpdated || forceUpdate)
            {
                isUpdated = false;

                strokeBrush?.Dispose();
                strokeBrush = new d2.SolidColorBrush(Renderer.Device, _stroke.ToColor4());

                strokeStyle?.Dispose();
                strokeStyle = new d2.StrokeStyle(Renderer.Factory, _strokeStyleProp);
            }
        }

        protected override void OnRender(DateTime time)
        {
            Renderer.Device.DrawLine(Point1, Point2, strokeBrush, Width, strokeStyle);
        }

        public override void EndRender()
        {
            Update();
            base.EndRender();
        }

        public override void Resized()
        {
            Update(true);
            base.Resized();
        }
    }
}
