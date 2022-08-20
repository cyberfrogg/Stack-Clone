using Core.BlockPlacing;
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
        public readonly BlockPlacerFactory BlockPlacerFactory;

        public GameDependencies(UiScreens uiScreens, GameFlowStrap gameFlowStrap, StackTowerFactory stackTowerFactory, BlockPlacerFactory blockPlacerFactory)
        {
            UiScreens = uiScreens;
            GameFlowStrap = gameFlowStrap;
            StackTowerFactory = stackTowerFactory;
            BlockPlacerFactory = blockPlacerFactory;
        }
    }
}