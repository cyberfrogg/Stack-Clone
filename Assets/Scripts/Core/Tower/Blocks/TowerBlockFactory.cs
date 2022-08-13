using System.Collections.Generic;
using Tweening;
using UnityEngine;

namespace Core.Tower.Blocks
{
    public class TowerBlockFactory : ITowerBlocksFactory
    {
        private readonly TowerBlock _blockPrefab;
        private readonly ITowerBlockSettings _towerBlockSettings;
        private readonly SimpleTweener _simpleTweener;

        public TowerBlockFactory(TowerBlock blockPrefab, ITowerBlockSettings towerBlockSettings, SimpleTweener simpleTweener)
        {
            _blockPrefab = blockPrefab;
            _towerBlockSettings = towerBlockSettings;
            _simpleTweener = simpleTweener;
        }
        
        public ITowerBlock CreateBlock()
        {
            return CreateBlock(_towerBlockSettings.Width);
        }
        public ITowerBlock CreateBlock(float width)
        {
            var block = GameObject.Instantiate(_blockPrefab);
            block.Initialize(_towerBlockSettings, _simpleTweener);
            return block;
        }
    }
}