using dWrite = SharpDX.DirectWrite;
using dWin = SharpDX.Windows;
using d2 = SharpDX.Direct2D1;
using d3_11 = SharpDX.Direct3D11;
using d3 = SharpDX.Direct3D;
using dx = SharpDX.DXGI;

using St2D.Utils;

using System;
using System.Windows.Forms;
using System.Drawing;

namespace St2D
{
    public class Renderer : AnimatedScene
    {
        #region [ Property ]
        public Color Background { get; set; } = Color.LightPink;

        public Control Target { get; }
        public dWrite.Factory WriteFactory { get; private set; }
        public d2.DeviceContext Device { get { return mDevice; } }
        public d2.Factory Factory { get { return mDevice.Factory; } }
        #endregion

        #region [ Render Variable ]
        private dWin.RenderLoop.RenderCallback mRenderCallback = null;

        protected dx.SwapChainDescription mSwapChainDesc;
        protected dx.SwapChain mSwapChain = null;
        protected d3_11.Device mD3Device = null;
        protected dx.Surface mSurface = null;
        protected d2.DeviceContext mDevice = null;
        protected d2.Resource resource = null;
        #endregion

        public Renderer(Control target) : base(null)
        {
            Target = target;
            InitRenderer();
        }

        public void Run()
        {
            dWin.RenderLoop.Run(Target, mRenderCallback);
        }

        public void Resize()
        {
            var size = Target.ClientSize;

            mDevice.Dispose();
            mSurface.Dispose();

            mSwapChain.ResizeBuffers(1, size.Width, size.Height,
                mSwapChainDesc.ModeDescription.Format,
                mSwapChainDesc.Flags);

            mSurface = dx.Surface.FromSwapChain(mSwapChain, 0);
            mDevice = new d2.DeviceContext(mSurface);

            mD3Device.ImmediateContext.ClearState();
            base.Resized();
        }

        protected virtual void InitRenderer()
        {
            mSwapChainDesc = new dx.SwapChainDescription()
            {
                BufferCount = 1,
                IsWindowed = true,
                OutputHandle = Target.Handle,
                SwapEffect = dx.SwapEffect.Discard,
                Usage = dx.Usage.RenderTargetOutput | dx.Usage.ShaderInput,
                Flags = dx.SwapChainFlags.None,
                ModeDescription = new dx.ModeDescription(0, 0, dx.Rational.Empty, dx.Format.B8G8R8A8_UNorm),
                SampleDescription = new dx.SampleDescription(1, 0)
            };

            d3_11.Device.CreateWithSwapChain(d3.DriverType.Hardware, d3_11.DeviceCreationFlags.BgraSupport, mSwapChainDesc, out mD3Device, out mSwapChain);
            mSurface = dx.Surface.FromSwapChain(mSwapChain, 0);

            WriteFactory = new dWrite.Factory();
            mDevice = new d2.DeviceContext(mSurface);
            
            mRenderCallback = new dWin.RenderLoop.RenderCallback(Render);
        }

        private void Render()
        {
            Device.BeginDraw();
            base.BeginRender(DateTime.Now);

            Device.EndDraw();
            mSwapChain.Present(0, dx.PresentFlags.None);

            base.EndRender();
        }

        protected override void OnRender(DateTime time)
        {
            Device.Clear(Background.ToColor4());
        }
    }
}