using Tweening;
using UnityEngine;

namespace Core.Tower.Blocks
{
    public class TowerBlockFactory : ITowerBlocksFactory
    {
        private readonly TowerBlock _blockPrefab;
        private readonly CutBlockPart _cutBlockPartPrefabPrefab;
        private readonly ITowerBlockSettings _towerBlockSettings;
        private readonly SimpleTweener _simpleTweener;

        public TowerBlockFactory(TowerBlock blockPrefab, CutBlockPart cutBlockPartPrefab, ITowerBlockSettings towerBlockSettings, SimpleTweener simpleTweener)
        {
            _blockPrefab = blockPrefab;
            _cutBlockPartPrefabPrefab = cutBlockPartPrefab;
            _towerBlockSettings = towerBlockSettings;
            _simpleTweener = simpleTweener;
        }
        
        public ITowerBlock CreateBlock()
        {
            return CreateBlock(null);
        }
        public ITowerBlock CreateBlock(ITowerBlock lastBlock)
        {
            var block = GameObject.Instantiate(_blockPrefab);
            block.Initialize(_towerBlockSettings, this, _simpleTweener, lastBlock);
            return block;
        }
        public CutBlockPart CreateCutBlockPart()
        {
            var cutPart = GameObject.Instantiate(_cutBlockPartPrefabPrefab);
            return cutPart;
        }
    }
}