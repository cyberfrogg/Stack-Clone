﻿using System.Collections.Generic;
using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Tower
{
    public class StackTower : IStackTower
    {
        public Vector3 NextBlockPosition => _blockPositionCalculator.GetNextPosition(_blocks.Count);
        
        private readonly IStackTowerSettings _settings;
        private readonly List<ITowerBlock> _blocks = new();
        private readonly BlockPositionCalculator _blockPositionCalculator;

        public StackTower(IStackTowerSettings settings)
        {
            _settings = settings;
            _blockPositionCalculator = new BlockPositionCalculator(_settings.BlockHeight);
        }
        
        public void PlaceBlock(ITowerBlock block)
        {
            block.Position = _blockPositionCalculator.GetNextPosition(_blocks.Count);
            block.Drop();
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
                block?.Destroy();
            }
            _blocks.Clear();
        }
    }
}