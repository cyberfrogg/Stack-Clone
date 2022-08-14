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
            return CreateBlock(_towerBlockSettings.TowerCenter, new Vector3(_towerBlockSettings.Width, 1, _towerBlockSettings.Width));
        }
        public ITowerBlock CreateBlock(Vector3 lastBlockCenter, Vector3 lastBlockScale)
        {
            var block = GameObject.Instantiate(_blockPrefab);
            block.Initialize(_towerBlockSettings, _simpleTweener, lastBlockCenter, lastBlockScale);
            return block;
        }
    }
}