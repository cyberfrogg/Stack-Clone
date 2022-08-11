using Core.GameFlow;
using Core.Tower;
using Core.UI.Screens;

namespace Core
{
    public class GameDependencies
    {
        public readonly UiScreens UiScreens;
        public readonly GameFlowStrap GameFlowStrap;
        public readonly StackTowerFactory StackTowerFactory;

        public GameDependencies(UiScreens uiScreens, GameFlowStrap gameFlowStrap, StackTowerFactory stackTowerFactory)
        {
            UiScreens = uiScreens;
            GameFlowStrap = gameFlowStrap;
            StackTowerFactory = stackTowerFactory;
        }
    }
}