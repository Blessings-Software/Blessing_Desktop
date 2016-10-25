using St2D;
using c = St2D.Components;

using Morphing;
using TextMorphing.Controls;

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;

namespace TextMorphing
{
    public partial class SurfaceWindow : Form
    {
        Renderer renderer;

        public SurfaceWindow()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            
            this.ClientSize = Properties.Resources.background.Size;

            renderer = new Renderer(this);

            /* ** Create Scenes ** */

            // Background
            var background = new c.Image(renderer);
            background.SetSource(Properties.Resources.background);

            renderer.AddScene(background);

            // FPS
#if DEBUG
            renderer.AddScene(new c.FPSScene(renderer));
#endif
            
            // Leaf
            var lm = new LeafManager(renderer);
            lm.Size = new SharpDX.Size2(this.ClientSize.Width, this.ClientSize.Height);
            lm.Interval = TimeSpan.FromMilliseconds(0);

            lm.Sources.AddRange(
                new Bitmap[]
                {
                    Properties.Resources.leaf_1,
                    Properties.Resources.leaf_2,
                    Properties.Resources.leaf_3,
                    Properties.Resources.leaf_4,
                    Properties.Resources.leaf_5
                });

            renderer.AddScene(lm);
            lm.Begin();

            // Morph
            var f = new Font("맑은고딕", 128, FontStyle.Bold);
            var mm = new MorphingManager(renderer);
            mm.AddMorphing(
                CharacterFactory.ToBitmap("봄", f.Clone() as Font),
                CharacterFactory.ToBitmap("봄봄", f.Clone() as Font));

            renderer.AddScene(mm);
            mm.Begin();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            renderer.Run();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            renderer.Resize();

            base.OnResizeEnd(e);
        }

        protected override void OnPaint(PaintEventArgs e) {}
        protected override void OnPaintBackground(PaintEventArgs e) {}
    }
}