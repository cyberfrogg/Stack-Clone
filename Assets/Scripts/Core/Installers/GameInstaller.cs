using Core.Camera;
using UnityEngine;

namespace Core.Installers
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private UiScreensInstaller _uiScreensInstaller;
        [SerializeField] private GameFlowInstaller _gameFlowInstaller;
        [SerializeField] private StackTowerInstaller _stackTowerInstaller;
        [SerializeField] private TowerBlocksInstaller _towerBlocksInstaller;
        [SerializeField] private BlockPlacerInstaller _blockPlacerInstaller;
        [SerializeField] private CameraInstaller _cameraInstaller;
        
        private Game _game;
        
        private void Awake()
        {
            _game = CreateGame();
            _game.Start();
        }

        private Game CreateGame()
        {
            var gameFlowStrap = _gameFlowInstaller.Create();
            var towerBlocksFactory = _towerBlocksInstaller.CreateTowerBlocksFactory();
            
            GameDependencies dependencies = new GameDependencies(
                _uiScreensInstaller.Create(gameFlowStrap),
                gameFlowStrap,
                _stackTowerInstaller.CreateStackTowerFactory(towerBlocksFactory),
                _blockPlacerInstaller.CreateFactory(towerBlocksFactory),
                _cameraInstaller.GetCamera()
                );
            
            Game game = new Game(dependencies);
            return game;
        }
    }
}
