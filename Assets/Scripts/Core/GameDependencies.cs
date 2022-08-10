using Core.GameFlow;
using Core.UI.Screens;

namespace Core
{
    public class GameDependencies
    {
        public readonly UiScreens UiScreens;
        public readonly GameFlowStrap GameFlowStrap;

        public GameDependencies(UiScreens uiScreens, GameFlowStrap gameFlowStrap)
        {
            UiScreens = uiScreens;
            GameFlowStrap = gameFlowStrap;
        }
    }
}