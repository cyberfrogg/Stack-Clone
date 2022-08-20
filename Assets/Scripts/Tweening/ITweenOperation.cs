using System;

namespace Tweening
{
    public interface ITweenOperation
    {
        event Action<ITweenOperation> Complete;
        event Action<ITweenOperation> Stopped;
        void Update();
        void Stop();
    }
}