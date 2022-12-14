using System;
using Core.GameFlow;
using UnityEngine;

namespace Core.UI.Screens.Impl
{
    public class UiScreen : MonoBehaviour, IUiScreen
    {
        public event Action<bool> Toggled;
        public event Action<UiScreen> ToggledSolo;

        protected GameFlowStrap GameFlowStrap;
        
        public virtual void Initialzie(GameFlowStrap gameFlowStrap)
        {
            GameFlowStrap = gameFlowStrap;
        }
        
        public void ToggleImmediately(bool isEnabled)
        {
            Toggle(isEnabled);
        }
        public virtual void Toggle(bool isEnabled, Action toggleDone)
        {
            Toggle(isEnabled);
            toggleDone?.Invoke();
        }
        public virtual void ShowOne(Action toggleDone)
        {
            Toggle(true);
            ToggledSolo?.Invoke(this);
            toggleDone?.Invoke();
        }

        private void Toggle(bool isEnabled)
        {
            gameObject.SetActive(isEnabled);
            Toggled?.Invoke(isEnabled);
        }
    }
}