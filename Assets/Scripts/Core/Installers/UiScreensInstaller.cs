using System;
using System.Collections.Generic;
using Core.UI.Screens;
using Core.UI.Screens.Impl;
using UnityEngine;

namespace Core.Installers
{
    [Serializable]
    public class UiScreensInstaller
    {
        [SerializeField] private List<UiScreen> _screens;
        
        public UiScreens Create()
        {
            return new UiScreens(_screens);
        }
    }
}