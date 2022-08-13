using System;

namespace Tweening
{
    public interface ITweenOperation
    {
        event Action<ITweenOperation> Complete; 
        void Update();
    }
}