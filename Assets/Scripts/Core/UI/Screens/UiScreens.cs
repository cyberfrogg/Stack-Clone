using System;
using System.Collections.Generic;
using System.Linq;
using Core.UI.Screens.Impl;
using UnityEngine;

namespace Core.UI.Screens
{
    public class UiScreens
    {
        private readonly IReadOnlyCollection<IUiScreen> _screens;
        
        public UiScreens(IEnumerable<IUiScreen> screens)
        {
            _screens = screens.ToList().AsReadOnly();

            foreach (UiScreen uiScreen in _screens)
            {
                uiScreen.Toggled += OnScreenToggled;
                uiScreen.ToggledSolo += OnScreenToggledSolo;
            }
        }
        public void Destroy()
        {
            foreach (UiScreen uiScreen in _screens)
            {
                uiScreen.Toggled -= OnScreenToggled;
                uiScreen.ToggledSolo -= OnScreenToggledSolo;
            }
        }
        
        public IUiScreen GetScreen<T>() where T : UiScreen
        {
            var foundedScreens = _screens.OfType<T>().ToList();
            if (foundedScreens.Count() > 1)
                Debug.LogWarning($"There are 2 or more screens of type: {nameof(T)}");

            if (!foundedScreens.Any())
                throw new ArgumentException($"There are no screens of type: {nameof(T)}");

            return foundedScreens.First();
        }
        
        private void OnScreenToggled(bool isEnabled)
        {

        }
        private void OnScreenToggledSolo(UiScreen senderScreen)
        {
            foreach (UiScreen screen in _screens)
            {
                if (screen == senderScreen)
                    continue;

                screen.ToggleImmediately(false);
            }
        }
    }
}