using SharpDX;
using St2D.Components;

using System;
using St2D;
using d = System.Drawing;
using St2D.Collections;

namespace TextMorphing.Controls
{
    public class Leaf : Image
    {
        private static Random Random = new Random();

        public LeafManager Manager { get; set; }
        public Vector2 StartPosition { get; }
        public Vector2 EndPosition { get; }
        public float StartAngle { get; }
        public float EndAngle { get; }
        public TimeSpan Duration { get; }
        public TimeSpan LifeTime { get; }

        private DateTime? BeginTime;
        private DateTime? EndTime;

        public Leaf(Renderer renderer,
            d.Bitmap source,
            Vector2 startPos,
            Vector2 endPos,
            TimeSpan duration,
            TimeSpan lifeTime,
            float startRotate = 0, float endRotate = 0) : base(renderer)
        {
            this.StartPosition = startPos;
            this.EndPosition = endPos;
            this.StartAngle = startRotate;
            this.EndAngle = endRotate;
            this.Duration = duration;
            this.LifeTime = lifeTime;

            SetSource(source);
        }

        public void Begin()
        {
            if (!BeginTime.HasValue)
            {
                BeginTime = DateTime.Now;
            }
        }

        protected override void OnRender(DateTime time)
        {
            TimeSpan? delta = time - (BeginTime ?? EndTime);

            if (delta.HasValue)
            {
                double t = Math.Min(delta.Value.TotalMilliseconds, Duration.TotalMilliseconds);
                float p = (float)(t / Duration.TotalMilliseconds);

                if (BeginTime.HasValue)
                {
                    Location = StartPosition + (EndPosition - StartPosition) * new Vector2(p, p);
                    Rotate = StartAngle + (EndAngle - StartAngle) * p;
                }
                else if (EndTime.HasValue)
                {
                    this.Opacity = 1f - p;
                }

                if (p == 1f)
                {
                    if (BeginTime.HasValue)
                    {
                        BeginTime = null;
                        EndTime = time;
                    }
                    else if (EndTime.HasValue)
                    {
                        EndTime = null;

                        ((Manager ?? (IScene)Renderer).RenderScenes as LazyActionList<IScene>)
                            .LazyRemove(this, obj => (obj as Leaf).Dispose());
                    }
                }
            }

            base.OnRender(time);
        }

        public static Leaf Create(LeafManager lm)
        {
            var source = lm.GetLeafSource();

            float scale = Random.Next(10, 50) / 100f;
            float dur = Random.Next(3, 6) * 1000;
            float lt = Random.Next(2, 5) * 1000;

            float sx = Random.NextFloat(-lm.Size.Width / 2f, lm.Size.Width / 3 * 2);
            float sy = -lm.Size.Height / 5;
            float sRot = Random.Next(0, 360);

            float ex = sx * Random.NextFloat(1.5f, 3f);
            float ey = lm.Size.Height - Random.NextFloat(0, source.Height * scale);
            float eRot = Random.Next(360, 360 * 4);

            var lf = new Leaf(lm.Renderer,
                source,
                new Vector2(sx, sy),
                new Vector2(ex, ey),
                TimeSpan.FromMilliseconds(dur),
                TimeSpan.FromMilliseconds(lt),
                sRot, eRot)
            {
                Scale = scale
            };

            lf.Manager = lm;
            lf.Begin();

            return lf;
        }
    }
}