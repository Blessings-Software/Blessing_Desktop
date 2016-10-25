using St2D.Collections;
using System;

namespace St2D
{
    public interface IScene
    {
        ILazyList<IScene> RenderScenes { get; }

        void BeginRender(DateTime time);
        void EndRender();
        void Resized();
    }
}