using St2D;
using c = St2D.Components;

using Morphing;
using TextMorphing.Controls;

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace TextMorphing
{
    public partial class SurfaceWindow : Form
    {
        protected bool m_isFixed = false;
        public bool IsFixed
        { get { return m_isFixed; } }
        Renderer renderer;
        public Screen OwnerScreen
        {
            get
            {
                if (OwnerScreenIndex < Screen.AllScreens.Length)
                    return Screen.AllScreens[OwnerScreenIndex];
                return Screen.PrimaryScreen;
            }
        }

        protected Task m_checkParent = null;
        protected bool m_onRunning = false;
        protected EventWaitHandle m_waitHandle = null;
        private int m_ownerScreenIndex = 0;
        public int OwnerScreenIndex
        {
            get { return m_ownerScreenIndex; }
            set
            {
                if (value < 0)
                    value = 0;
                else if (value >= Screen.AllScreens.Length)
                    value = 0;

                if (m_ownerScreenIndex != value)
                {
                    m_ownerScreenIndex = value;

                    PinToBackground();
                }
            }
        }
        protected readonly object m_lockFlag = new object();
        protected bool m_needUpdate = false;
        protected bool PinToBackground()
        {

            m_isFixed = BehindDesktopIcon.FixBehindDesktopIcon(this.Handle);

            if (m_isFixed)
            {
                ScreenUtility.FillScreen(this, OwnerScreen);
            }


            return m_isFixed;
        }
        public SurfaceWindow()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            
            this.ClientSize = Properties.Resources.background.Size;
            PinToBackground();
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
            /*
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
            */
            // Morph
            var f = new Font("맑은고딕", 128, FontStyle.Bold);
            var mm = new MorphingManager(renderer);
            mm.AddMorphing(
                CharacterFactory.ToBitmap("御坂", f.Clone() as Font),
                CharacterFactory.ToBitmap("美琴", f.Clone() as Font));

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