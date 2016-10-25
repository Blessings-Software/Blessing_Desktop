using System;
using System.Drawing;

namespace St2D.Components
{
    public class FPSScene : TextBlock
    {
        public int Fps { get; private set; }

        #region [ Local Variable ]
        private DateTime time;
        private int frameCount;
        #endregion

        public FPSScene(Renderer renderer) : base(renderer)
        {
            this.Font = new Font("Console", 12);
            this.Foreground = Color.Black;

            this.Location = new SharpDX.Vector2(10, 10);
            this.Size = new SharpDX.Size2(100, 20);
        }

        protected override void OnRender(DateTime time)
        {
            frameCount++;
            if ((time - this.time).TotalMilliseconds >= 1000)
            {
                Fps = frameCount;
                frameCount = 0;
                this.time = time;

                this.Text = $"FPS: {Fps}";
            }

            base.OnRender(time);
        }
    }
}