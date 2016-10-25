using s = SharpDX;
using d2 = SharpDX.Direct2D1;

using St2D;
using St2D.Components;

using System;
using System.Drawing;
using St2D.Utils;

namespace TextMorphing.Controls
{
    // 어릴적 짯던 소스라 매우 더럽다..
    public class PtrChain : Line
    {
        private PointF _oPt;
        private PtrPoint _pt;

        private PtrPoint _pt_ch;

        private PtrChain _ch;
        public PointF ToPoint { get; set; }

        public bool IsConnected
        {
            get { return _ch != null; }
        }

        public void Processing(double d)
        {
            s.Vector2 dPt = new s.Vector2(ToPoint.X - _oPt.X, ToPoint.Y - _oPt.Y);
            dPt.X = (float)(dPt.X * d);
            dPt.Y = (float)(dPt.Y * d);

            _pt.X = _oPt.X + dPt.X;
            _pt.Y = _oPt.Y + dPt.Y;
        }

        protected override void OnRender(DateTime time)
        {
            if (IsConnected)
            {
                Point1 = new s.Vector2(_pt.X, _pt.Y);
                Point2 = new s.Vector2(_pt_ch.X, _pt_ch.Y);
            }

            base.OnRender(time);
        }

        public PtrChain(Renderer renderer, PointF pt) : base(renderer)
        {
            _pt = new PtrPoint(pt.X, pt.Y);
            _oPt = pt;
        }
        
        public PtrPoint Point
        {
            get { return _pt; }
        }

        public PtrPoint ChainPoint
        {
            get { return _pt_ch; }
        }
        
        public void Connect(PtrChain chain)
        {
            if (_ch == null)
            {
                _ch = chain;
                _pt_ch = _ch.Point;
            }
        }
    }
}
