using System;
using Core.Tower;
using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Installers
{
    [Serializable]
    public class TowerBlocksInstaller
    {
        [SerializeField] private TowerBlock _towerBlockPrefab;
        
        public ITowerBlocksFactory CreateTowerBlocksFactory()
        {
            return new TowerBlockFactory(_towerBlockPrefab);
        }
    }
}