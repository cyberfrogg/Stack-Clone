using UnityEngine;

namespace Core.Installers
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private UiScreensInstaller _uiScreensInstaller;
        
        private Game _game;
        
        private void Awake()
        {
            _game = CreateGame();
            _game.Start();
        }

        private Game CreateGame()
        {
            GameDependencies dependencies = new GameDependencies(_uiScreensInstaller.Create());
            
            Game game = new Game(dependencies);
            return game;
        }
    }
}
