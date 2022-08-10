using System;

namespace Core.UI.Screens
{
    public interface IUiScreen
    {
        void ToggleImmediately(bool isEnabled);
        void Toggle(bool isEnabled, Action toggleDone);
        void ShowOne(Action toggleDone);
    }
}