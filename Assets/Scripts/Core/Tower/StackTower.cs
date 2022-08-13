using System.Collections.Generic;
using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Tower
{
    public class StackTower : IStackTower
    {
        public Vector3 NextBlockPosition => _blockPositionCalculator.GetNextPosition(_blocks.Count);
        
        private readonly IStackTowerSettings _settings;
        private readonly List<TowerBlock> _blocks = new();
        private readonly BlockPositionCalculator _blockPositionCalculator;

        public StackTower(IStackTowerSettings settings)
        {
            _settings = settings;
            _blockPositionCalculator = new BlockPositionCalculator(_settings.BlockHeight);
        }
        
        public void PlaceBlock(TowerBlock block)
        {
            block.transform.position = _blockPositionCalculator.GetNextPosition(_blocks.Count);
            _blocks.Add(block);
        }
        
        public void Destroy()
        {
            RemoveAllBlocks();
        }

        private void RemoveAllBlocks()
        {
            foreach (var block in _blocks)
            {
                if (block != null)
                {
                    block.Destroy();
                }
            }
            _blocks.Clear();
        }
    }
}