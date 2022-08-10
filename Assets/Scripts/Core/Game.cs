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
            _dependencies.GameFlowStrap.GameStart.Run();
        }

        private void OnGameStart()
        {
            Debug.Log("Game started");
        }

        public void Reset()
        {
            
        }
    }
}
