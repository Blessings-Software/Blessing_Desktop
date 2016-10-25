using s = SharpDX;
using d2 = SharpDX.Direct2D1;

using St2D;
using St2D.Components;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMorphing.Controls
{
    public class MorphChain : UIScene
    {
        public MorphData Data1 { get; }
        public MorphData Data2 { get; }

        public List<PtrChain> LinkedData;

        private PtrPoint[] trace1;
        private PtrPoint[] trace2;

        public MorphChain(Renderer renderer, MorphData md1, MorphData md2) : base(renderer)
        {
            LinkedData = new List<PtrChain>();

            Data1 = md1;
            Data2 = md2;

            Matching();
            Processing(0);
        }

        public override void BeginRender(DateTime time)
        {
            Renderer.Device.Transform = s.Matrix3x2.Translation(Location);

            base.BeginRender(time);

            Renderer.Device.Transform = s.Matrix3x2.Identity;
        }

        protected override void OnRender(DateTime time)
        {
        }

        public void Processing(float p)
        {
            Location = new s.Vector2(
                Renderer.Target.ClientSize.Width / 2 - Data1.Source.Width / 2 - (Data2.Source.Width - Data1.Source.Width) / 2 * p,
                Renderer.Target.ClientSize.Height / 2 - Data1.Source.Height / 2);

            for (int i = 0; i < LinkedData.Count; i++)
            {
                LinkedData[i].Processing(p);
            }
        }

        private void Matching()
        {
            // 어릴적 짯던 소스라 매우 더럽다..
            this.trace1 = Data1.Trace().Select(pt => new PtrPoint(pt.X, pt.Y)).ToArray();
            this.trace2 = Data2.Trace().Select(pt => new PtrPoint(pt.X, pt.Y)).ToArray();

            var cQue = new Queue();
            PtrChain lCh = null;
            PtrChain lrCh = null;

            for (int i = 0; i <= trace1.Length - 1; i++)
            {
                int abs_index = (int)((i / (trace1.Length - 1f)) * (trace2.Length - 1));

                if (lCh == null)
                {
                    lCh = CreateSakuraChain(trace1[i].ToPoint());
                }
                else
                {
                    PointF tPt = trace2[abs_index].ToPoint();
                    PointF tPt2 = trace2[Math.Max(abs_index - 1, 0)].ToPoint();

                    PtrChain rCh = CreateSakuraChain(trace1[i].ToPoint());

                    double d = MorphData.Distance(rCh.Point.ToPoint(), lCh.Point.ToPoint());
                    double d2 = MorphData.Distance(tPt2, tPt);

                    if (d >= 3 * 2 | d2 >= 3 * 2)
                    {
                        cQue.Enqueue(lrCh);

                        lCh = null;
                        continue;
                    }

                    lCh.ToPoint = tPt;
                    rCh.ToPoint = tPt2;
                    lCh.Connect(rCh);

                    lrCh = rCh;

                    LinkedData.Add(lCh);
                    LinkedData.Add(rCh);

                    AddScene(lCh);
                    AddScene(rCh);

                    lCh = null;
                    i--;
                }
            }
        }

        private PtrChain CreateSakuraChain(PointF point)
        {
            return new PtrChain(Renderer, point)
            {
                Width = 6,
                StrokeStyle = new d2.StrokeStyleProperties() { StartCap= d2.CapStyle.Round, EndCap = d2.CapStyle.Round },
                Stroke = Color.FromArgb(204, 66, 111)
            };
        }
    }
}
