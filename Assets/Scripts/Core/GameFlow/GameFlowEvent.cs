using System;

namespace Core.GameFlow
{
    public class GameFlowEvent
    {
        public event Action Started;

        public void Run()
        {
            Started?.Invoke();
        }
    }
}