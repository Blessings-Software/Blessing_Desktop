using St2D.Collections;
using System;

namespace St2D
{
    public abstract class AnimatedScene : IScene, IDisposable
    {
        public Renderer Renderer { get; }
        public ILazyList<IScene> RenderScenes { get; }
        
        public AnimatedScene(Renderer renderer)
        {
            this.Renderer = renderer;
            this.RenderScenes = new LazyActionList<IScene>();
        }

        public virtual void BeginRender(DateTime time)
        {
            this.OnRender(time);

            for (int i = 0; i < RenderScenes.Count; i++)
                RenderScenes[i].BeginRender(time);
        }

        public virtual void EndRender()
        {
            for (int i = 0; i < RenderScenes.Count; i++)
                RenderScenes[i].EndRender();

            RenderScenes.Apply();
        }

        protected abstract void OnRender(DateTime time);

        public void AddScene(IScene scene)
        {
            RenderScenes.Add(scene);
        }

        public void RemoveScene(IScene scene)
        {
            RenderScenes.Remove(scene);
        }

        public virtual void Resized()
        {
            for (int i = 0; i < RenderScenes.Count; i++)
                RenderScenes[i].Resized();
        }

        public virtual void Dispose()
        {
        }
    }
}