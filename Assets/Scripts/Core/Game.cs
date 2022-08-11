using Core.Tower;
using Core.UI.Screens.Impl;
using UnityEngine;

namespace Core
{
    public class Game
    {
        private readonly GameDependencies _dependencies;

        private StackTower _tower;

        public Game(GameDependencies dependencies)
        {
            _dependencies = dependencies;
        }

        public void Start()
        {
            _dependencies.UiScreens.GetScreen<HomeScreen>().ShowOne(null);
            _dependencies.GameFlowStrap.GameStart.Started += OnGameStart;
        }

        private void OnGameStart()
        {
            _dependencies.UiScreens.GetScreen<GameScreen>().ShowOne(null);

            _tower = _dependencies.StackTowerFactory.CreateTower();
        }

        public void Reset()
        {
            
        }
    }
}
