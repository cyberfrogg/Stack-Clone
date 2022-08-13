using System.Collections.Generic;
using UnityEngine;

namespace Core.Tower.Blocks
{
    public class TowerBlockFactory : ITowerBlocksFactory
    {
        private readonly TowerBlock _blockPrefab;
        private readonly ITowerBlockSettings _towerBlockSettings;

        public TowerBlockFactory(TowerBlock blockPrefab, ITowerBlockSettings towerBlockSettings)
        {
            _blockPrefab = blockPrefab;
            _towerBlockSettings = towerBlockSettings;
        }
        
        public ITowerBlock CreateBlock()
        {
            return CreateBlock(_towerBlockSettings.Width);
        }
        public ITowerBlock CreateBlock(float width)
        {
            var block = GameObject.Instantiate(_blockPrefab);
            block.Initialize(_towerBlockSettings);
            return block;
        }
    }
}