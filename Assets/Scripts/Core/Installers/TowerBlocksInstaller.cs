using System;
using Core.Settings;
using Core.Tower;
using Core.Tower.Blocks;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Installers
{
    [Serializable]
    public class TowerBlocksInstaller
    {
        [SerializeField] private TowerBlock _towerBlockPrefab;
        [SerializeField, Required] private TowerBlockSettings _towerBlockSettings;
        
        public ITowerBlocksFactory CreateTowerBlocksFactory()
        {
            return new TowerBlockFactory(_towerBlockPrefab, _towerBlockSettings);
        }
    }
}