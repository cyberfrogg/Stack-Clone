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
        [SerializeField, Required] private Transform _towerSpawnpoint;
        [SerializeField, Required] private StackTowerSettings _settings;

        public StackTowerFactory CreateStackTowerFactory(ITowerBlocksFactory towerBlocksFactory)
        {
            return new StackTowerFactory(_settings, towerBlocksFactory);
        }
    }
}