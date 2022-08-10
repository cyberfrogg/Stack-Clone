using UnityEngine;

namespace Core.Installers
{
    public class GameInstaller : MonoBehaviour
    {
        private Game _game;
        
        private void Awake()
        {
            _game = CreateGame();
            _game.Start();
        }

        private Game CreateGame()
        {
            GameDependencies dependencies = new GameDependencies();
            Game game = new Game(dependencies);
            return game;
        }
    }
}
