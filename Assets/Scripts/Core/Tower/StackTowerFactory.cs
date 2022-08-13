using System;
using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Tower
{
    public class StackTowerFactory
    {
        private readonly IStackTowerSettings _settings;
        private readonly ITowerBlockSettings _blockSettings;
        private readonly ITowerBlocksFactory _towerBlocksFactory;

        public StackTowerFactory(IStackTowerSettings settings, ITowerBlocksFactory towerBlocksFactory, ITowerBlockSettings blockSettings)
        {
            _settings = settings;
            _blockSettings = blockSettings;
            _towerBlocksFactory = towerBlocksFactory;
        }

        public StackTower CreateTower()
        {
            StackTower stackTower = new StackTower(_settings, _blockSettings);

            for (int i = 0; i < _settings.InitialBlocksCount; i++)
            {
                stackTower.PlaceBlockAsIdeal(_towerBlocksFactory.CreateBlock());
            }
            
            return stackTower;
        }
    }
}