using d2 = SharpDX.Direct2D1;

using St2D.Utils;

using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace St2D.Components
{
    public class Image : UIScene
    {
        public float Scale { get; set; } = 1f;
        public float Rotate { get; set; } = 0f;
        public float Opacity { get; set; } = 1f;
        public d2.Bitmap Source { get; private set; } = null;

        private string fileNameBuffer = null;
        private Bitmap bmpBuffer;
        private bool isUpdated = false;

        public Image(Renderer renderer) : base(renderer)
        {
        }

        public void SetSource(string fileName)
        {
            bmpBuffer = null;
            fileNameBuffer = fileName;

            isUpdated = true;
        }

        public void SetSource(Bitmap bmp)
        {
            fileNameBuffer = null;
            bmpBuffer = bmp;

            isUpdated = true;
        }

        private void Update(bool forceUpdate = false)
        {
            if (isUpdated || forceUpdate)
            {
                isUpdated = false;
                Source?.Dispose();

                if (bmpBuffer != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        bmpBuffer.Save(ms, ImageFormat.Png);
                        Source = Renderer.Device.FromStream(ms);
                    }
                }

                if (fileNameBuffer != null)
                {
                    Source = Renderer.Device.FromFile(fileNameBuffer);
                }

                this.Size = Source.PixelSize;
            }
        }
        
        protected override void OnRender(DateTime time)
        {
            var radian = Rotate * Math.PI / 180;

            Renderer.Device.Transform = 
                Matrix3x2.Rotation((float)radian, new Vector2(Size.Width / 2, Size.Height / 2))
                * Matrix3x2.Scaling(Scale)
                * Matrix3x2.Translation(Location);

            if (Source != null)
                Renderer.Device.DrawBitmap(Source, new RawRectangleF(0, 0, Size.Width, Size.Height), Opacity, d2.BitmapInterpolationMode.Linear);

            Renderer.Device.Transform = Matrix3x2.Identity;
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

        public override void Dispose()
        {
            Source?.Dispose();
        }
    }
}