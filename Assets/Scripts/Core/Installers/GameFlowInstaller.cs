using System;
using Core.GameFlow;

namespace Core.Installers
{
    [Serializable]
    public class GameFlowInstaller
    {
        public GameFlowStrap Create()
        {
            return new GameFlowStrap(new GameFlowEvent());
        }
    }
}