using Core.UI.Screens.Impl;
using UnityEngine;

namespace Core
{
    public class Game
    {
        private readonly GameDependencies _dependencies;

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
        }

        public void Reset()
        {
            
        }
    }
}
