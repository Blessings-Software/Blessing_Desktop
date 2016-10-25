using dWrite = SharpDX.DirectWrite;
using d2 = SharpDX.Direct2D1;

using St2D.Utils;

using System;
using System.Drawing;

namespace St2D.Components
{
    public class TextBlock : UIScene
    {
        #region [ Property ]
        public string Text { get; set; } = string.Empty;
        public Color Foreground
        {
            get { return _foreground; }
            set { _foreground = value;  isUpdated = true; }
        }
        public Font Font
        {
            get { return _font; }
            set { _font = value; isUpdated = true; }
        }
        #endregion

        #region [ Resource ]
        private Font _font;
        private Color _foreground = Color.Black;
        private bool isUpdated = false;

        private d2.SolidColorBrush foregroundBrush;
        private dWrite.TextFormat tFormat;
        #endregion

        public TextBlock(Renderer renderer) : base(renderer)
        {
            Font = Renderer.Target.Font;
            Update(true);
        }

        protected override void OnRender(DateTime time)
        {
            Renderer.Device.DrawText(Text, tFormat, GetBound(), foregroundBrush);
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
            tFormat?.Dispose();
            foregroundBrush?.Dispose();
            Font?.Dispose();
        }

        private void Update(bool updateForce = false)
        {
            if (isUpdated || updateForce)
            {
                isUpdated = false;

                tFormat?.Dispose();
                tFormat = CreateTextFormat(this.Font);

                foregroundBrush?.Dispose();
                foregroundBrush = new d2.SolidColorBrush(Renderer.Device, Foreground.ToColor4());
            }
        }

        private dWrite.TextFormat CreateTextFormat(Font font)
        {
            var fw = dWrite.FontWeight.Normal;
            var fs = dWrite.FontStyle.Normal;

            if (font.Style == FontStyle.Bold) fw = dWrite.FontWeight.ExtraBold;
            if (font.Style == FontStyle.Italic) fs = dWrite.FontStyle.Italic;
            if (font.Style == FontStyle.Regular) fw = dWrite.FontWeight.Regular;

            return new dWrite.TextFormat(Renderer.WriteFactory, font.Name, fw, fs, font.Size);
        }
    }
}