using St2D;
using St2D.Components;

using System;
using System.Collections.Generic;
using System.Drawing;

namespace TextMorphing.Controls
{
    public class LeafManager : UIScene
    {
        public TimeSpan Interval { get; set; } = TimeSpan.FromMilliseconds(300);
        public List<Bitmap> Sources { get; set; }

#if DEBUG
        private TextBlock debug;
#endif
        private Random random = new Random();
        private DateTime beginTime;

        public LeafManager(Renderer renderer) : base(renderer)
        {
            Sources = new List<Bitmap>();

#if DEBUG
            debug = new TextBlock(renderer);
            debug.Font = new Font("Console", 12);
            debug.Location = new SharpDX.Vector2(10, 30);
            debug.Size = new SharpDX.Size2(100, 3);

            AddScene(debug);
#endif
        }

        public void Begin()
        {
            beginTime = DateTime.Now.AddMilliseconds(-Interval.TotalMilliseconds);
        }

        protected override void OnRender(DateTime time)
        {
            TimeSpan dt = time - beginTime;

            if (dt.TotalMilliseconds >= Interval.TotalMilliseconds)
            {
                beginTime = beginTime.AddTicks(Interval.Ticks);

                AddScene(Leaf.Create(this));
            }

#if DEBUG
            debug.Text = $"Leaf: {RenderScenes.Count}";
#endif
        }

        public Bitmap GetLeafSource()
        {
            if (Sources.Count == 0)
                return null;

            return Sources[random.Next(Sources.Count)];
        }
    }
}