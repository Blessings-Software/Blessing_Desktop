using St2D;
using St2D.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SharpDX;

namespace TextMorphing.Controls
{
    public class MorphingManager : UIScene
    {
        private List<MorphChain> chains = new List<MorphChain>();
        private List<PointGeometry> geos = new List<PointGeometry>();

        private bool isBegin = false;
        private double proc = 0;
        private bool tick = false;
        private int ridx = 0;

        public MorphingManager(Renderer renderer) : base(renderer)
        {
            
        }

        public void Begin()
        {
            isBegin = true;
        }

        protected override void OnRender(DateTime time)
        {
            if (isBegin)
            {
                if (tick)
                {
                    proc -= proc / 15d;
                    if (Math.Abs(proc) < 0.001)
                    {
                        proc = 0;
                        tick = false;
                    }
                }
                else
                {
                    proc += (1 - proc) / 15d;
                    if (Math.Abs(1 - proc) < 0.001)
                    {
                        proc = 1;
                        tick = true;
                    }
                }

                for (int i = 0; i < chains.Count; i++)
                {
                    chains[i].Processing((float)proc);
                }
            }
        }

        public void AddMorphing(Bitmap src1, Bitmap src2)
        {
            var mc = new MorphChain(Renderer, new MorphData(src1), new MorphData(src2));

            chains.Add(mc);
            Renderer.AddScene(mc);
        }
    }
}