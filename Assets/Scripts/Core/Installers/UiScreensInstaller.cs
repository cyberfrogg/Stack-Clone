using System;
using System.Collections.Generic;
using Core.GameFlow;
using Core.UI.Screens;
using Core.UI.Screens.Impl;
using UnityEngine;

namespace Core.Installers
{
    [Serializable]
    public class UiScreensInstaller
    {
        [SerializeField] private List<UiScreen> _screens;
        
        public UiScreens Create(GameFlowStrap gameFlowStrap)
        {
            InitializeScreens(_screens, gameFlowStrap);
            return new UiScreens(_screens);
        }

        private void InitializeScreens(IEnumerable<UiScreen> screens, GameFlowStrap gameFlowStrap)
        {
            foreach (var screen in screens)
            {
                screen.Initialzie(gameFlowStrap);
            }
        }
    }
}