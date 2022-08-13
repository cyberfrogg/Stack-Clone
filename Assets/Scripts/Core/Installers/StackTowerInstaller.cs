using System;
using Core.Settings;
using Core.Tower;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Installers
{
    [Serializable]
    public class StackTowerInstaller
    {
        [SerializeField, Required] private StackTowerSettings _settings;
        [SerializeField, Required] private TowerBlockSettings _blockSettings;

        public StackTowerFactory CreateStackTowerFactory(ITowerBlocksFactory towerBlocksFactory)
        {
            return new StackTowerFactory(_settings, towerBlocksFactory, _blockSettings);
        }
    }
}