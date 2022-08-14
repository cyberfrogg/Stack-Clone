using System.Collections.Generic;
using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Tower
{
    public class StackTower : IStackTower
    {
        public Vector3 NextBlockPosition => _blockPositionCalculator.GetNextPosition(_blocks.Count);
        
        private readonly IStackTowerSettings _settings;
        private readonly ITowerBlockSettings _blockSettings;
        private readonly List<ITowerBlock> _blocks = new();
        private readonly BlockPositionCalculator _blockPositionCalculator;

        public StackTower(IStackTowerSettings settings, ITowerBlockSettings blockSettings)
        {
            _settings = settings;
            _blockSettings = blockSettings;
            _blockPositionCalculator = new BlockPositionCalculator(_settings.BlockHeight);
        }
        
        public void PlaceBlock(ITowerBlock block)
        {
            FixMissPlacing(block);
            block.Drop();
            _blocks.Add(block);
        }
        public void PlaceBlockAsIdeal(ITowerBlock block)
        {
            block.Position = NextBlockPosition;
            block.Drop();
            _blocks.Add(block);
        }
        
        public void Destroy()
        {
            RemoveAllBlocks();
        }

        private void FixMissPlacing(ITowerBlock towerBlock)
        {
            float missDistance = GetMissDistance(towerBlock.Position);
            if (missDistance <= _settings.MissPlacingTolerance)
            {
                towerBlock.Position = NextBlockPosition;
            }
        }
        private void RemoveAllBlocks()
        {
            foreach (var block in _blocks)
            {
                block?.Destroy();
            }
            _blocks.Clear();
        }

        private float GetMissDistance(Vector3 position)
        {
            return Vector3.Distance(position, NextBlockPosition - new Vector3(0, 0, 0));
        }
    }
}