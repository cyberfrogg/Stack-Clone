using System;
using Core.Settings;
using Core.Tower;
using Core.Tower.Blocks;
using NaughtyAttributes;
using Tweening;
using UnityEngine;

namespace Core.Installers
{
    [Serializable]
    public class TowerBlocksInstaller
    {
        [SerializeField] private TowerBlock _towerBlockPrefab;
        [SerializeField] private CutBlockPart _towerCutBlockPartPrefab;
        [SerializeField, Required] private TowerBlockSettings _towerBlockSettings;
        [SerializeField, Required] private SimpleTweener _simpleTweener;
        
        public ITowerBlocksFactory CreateTowerBlocksFactory()
        {
            return new TowerBlockFactory(_towerBlockPrefab, _towerCutBlockPartPrefab, _towerBlockSettings, _simpleTweener);
        }
    }
}