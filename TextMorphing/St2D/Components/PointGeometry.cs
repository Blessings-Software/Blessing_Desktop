using s = SharpDX;
using d2 = SharpDX.Direct2D1;
using mi = SharpDX.Mathematics.Interop;

using St2D.Utils;

using System;
using System.Linq;
using System.Drawing;

namespace St2D.Components
{
    public class PointGeometry : UIScene
    {
        #region [ Property ]
        public float Width { get; set; } = 1f;

        public s.Vector2[] Points
        {
            get { return _points; }
            set { _points = value; isUpdated = true; }
        }

        public Color Stroke
        {
            get { return _stroke; }
            set { _stroke = value; isUpdated = true; }
        }

        public Color Fill
        {
            get { return _fill; }
            set { _fill = value; isUpdated = true; }
        }
        #endregion

        private Color _stroke = Color.Black;
        private Color _fill = Color.Transparent;
        private bool isUpdated = false;
        private s.Vector2[] _points;

        private d2.PathGeometry geometry;
        private d2.SolidColorBrush strokeBrush;
        private d2.SolidColorBrush fillBrush;

        public PointGeometry(Renderer renderer, s.Vector2[] pts) : base(renderer)
        {
            Points = pts;

            Update(true);
        }

        private void Update(bool forceUpdate = false)
        {
            if (isUpdated || forceUpdate)
            {
                isUpdated = false;

                geometry?.Dispose();
                geometry = new d2.PathGeometry(Renderer.Factory);

                var s = geometry.Open();

                s.BeginFigure(Points[0], d2.FigureBegin.Filled);
                s.AddLines(Points.Select(v2 => new mi.RawVector2(v2.X, v2.Y)).ToArray());
                s.EndFigure(d2.FigureEnd.Closed);
                s.Close();

                strokeBrush?.Dispose();
                strokeBrush = new d2.SolidColorBrush(Renderer.Device, _stroke.ToColor4());

                fillBrush?.Dispose();
                fillBrush = new d2.SolidColorBrush(Renderer.Device, _fill.ToColor4());
            }
        }

        protected override void OnRender(DateTime time)
        {
            Renderer.Device.Transform = s.Matrix3x2.Translation(Location);

            Renderer.Device.FillGeometry(geometry, fillBrush);
            Renderer.Device.DrawGeometry(geometry, strokeBrush, Width);

            Renderer.Device.Transform = s.Matrix3x2.Identity;
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