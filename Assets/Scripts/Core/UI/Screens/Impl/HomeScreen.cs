using System;
using Core.GameFlow;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Screens.Impl
{
    public class HomeScreen : UiScreen
    {
        [SerializeField, Required] private Button _startButton;

        public override void Initialzie(GameFlowStrap gameFlowStrap)
        {
            base.Initialzie(gameFlowStrap);
            _startButton.onClick.AddListener(OnStartButtonClick);
        }
        private void OnDestroy()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClick);
        }
        
        private void OnStartButtonClick()
        {
            GameFlowStrap.GameStart.Run();
        }
    }
}