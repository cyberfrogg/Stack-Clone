using Core.BlockPlacing;
using Core.Tower;
using Core.Tower.Blocks;
using Core.UI.Screens.Impl;
using UnityEngine;

namespace Core
{
    public class Game
    {
        private readonly GameDependencies _dependencies;

        private IStackTower _tower;
        private BlockPlacer _blockPlacer;

        public Game(GameDependencies dependencies)
        {
            _dependencies = dependencies;
        }

        public void Start()
        {
            _dependencies.UiScreens.GetScreen<HomeScreen>().ShowOne(null);
            _dependencies.GameFlowStrap.GameStart.Started += OnGameStart;
            _dependencies.GameFlowStrap.GameFailed.Started += OnGameFailed;
            _dependencies.GameFlowStrap.GameRestart.Started += OnGameRestart;
        }

        private void OnGameStart()
        {
            _dependencies.UiScreens.GetScreen<GameScreen>().ShowOne(null);
            _dependencies.Camera.ResetToDefaultTarget();

            _tower = _dependencies.StackTowerFactory.CreateTower();
            _tower.Failed += OnTowerFailed;
            _tower.BlockPlaced += OnBlockPlaced;
            _blockPlacer = _dependencies.BlockPlacerFactory.CreateBlockPlacer(_tower);
            _blockPlacer.CreateMovingBlock();
        }
        private void OnGameFailed()
        {
            _dependencies.UiScreens.GetScreen<FailScreen>().ShowOne(null);
            
            _blockPlacer.IsEnabled = false;
            _dependencies.Camera.SetTarget(null);
        }
        private void OnGameRestart()
        {
            Reset();
        }

        private void OnBlockPlaced(BlockPlaceResult placeResult)
        {
            _dependencies.Camera.SetTarget(placeResult.Block);
        }
        private void OnTowerFailed()
        {
            _dependencies.GameFlowStrap.GameFailed.Run();
        }


        public void Reset()
        {
            Cleanup();
            Start();
        }
        private void Cleanup()
        {
            _tower.Destroy();
            
            _dependencies.GameFlowStrap.GameStart.Started -= OnGameStart;
            _dependencies.GameFlowStrap.GameFailed.Started -= OnGameFailed;
            _dependencies.GameFlowStrap.GameRestart.Started -= OnGameRestart;
            
            _blockPlacer.Destroy();
            _blockPlacer = null;
        }
    }
}
