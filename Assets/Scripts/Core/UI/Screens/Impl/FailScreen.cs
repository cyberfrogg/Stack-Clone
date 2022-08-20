using Core.GameFlow;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Core.UI.Screens.Impl
{
    public class FailScreen : UiScreen
    {
        [SerializeField, Required] private Button _restartButton;

        public override void Initialzie(GameFlowStrap gameFlowStrap)
        {
            base.Initialzie(gameFlowStrap);
            _restartButton.onClick.AddListener(OnRestartButtonClick);
        }
        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        }
        
        private void OnRestartButtonClick()
        {
            GameFlowStrap.GameRestart.Run();
        }
    }
}