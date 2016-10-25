using SharpDX;
using SharpDX.Mathematics.Interop;
using System;

namespace St2D.Components
{
    public class UIScene : AnimatedScene
    {
        public Vector2 Location { get; set; }
        public Size2 Size { get; set; }

        public UIScene(Renderer renderer) : base(renderer)
        {
        }

        protected override void OnRender(DateTime time)
        {
        }

        public virtual RawRectangleF GetBound()
        {
            return new RawRectangleF(Location.X, Location.Y,
                Location.X + Size.Width, Location.Y + Size.Height);
        }
    }
}
