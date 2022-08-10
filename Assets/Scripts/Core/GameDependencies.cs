using Core.UI.Screens;

namespace Core
{
    public class GameDependencies
    {
        public readonly UiScreens UiScreens;

        public GameDependencies(UiScreens uiScreens)
        {
            UiScreens = uiScreens;
        }
    }
}