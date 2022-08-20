using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Tower
{
    public class StackTower : IStackTower
    {
        public event Action Failed;

        private bool _isFailed;

        private readonly IStackTowerSettings _settings;
        private readonly ITowerBlockSettings _blockSettings;
        private readonly List<ITowerBlock> _blocks = new();
        private readonly BlockPositionCalculator _blockPositionCalculator;

        public Vector3 NextBlockPosition => _blockPositionCalculator.GetNextPosition(_blocks.Count);
        public ITowerBlock LastBlock => GetLastBlock();
        
        public StackTower(IStackTowerSettings settings, ITowerBlockSettings blockSettings)
        {
            _settings = settings;
            _blockSettings = blockSettings;
            _blockPositionCalculator = new BlockPositionCalculator(_settings.BlockHeight);
        }
        
        public void PlaceBlock(ITowerBlock block, Action<BlockPlaceResult> blockPlaceComplete)
        {
            FixMissPlacing(block);
            var missDistance = GetMissDistance(block.Position);
            var placeResult = block.Drop(missDistance <= _settings.MissPlacingTolerance ? 0 : missDistance, LastBlock);
            _blocks.Add(block);
            blockPlaceComplete?.Invoke(placeResult);
            OnBlockPlaced(placeResult);
        }
        public void PlaceBlockAsIdeal(ITowerBlock block)
        {
            block.Position = NextBlockPosition;
            block.Drop(0, LastBlock);
            _blocks.Add(block);
        }
        
        public void Destroy()
        {
            RemoveAllBlocks();
        }

        private void FixMissPlacing(ITowerBlock towerBlock)
        {
            var missDistance = GetMissDistance(towerBlock.Position);
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
            var lastBlockPos = LastBlock.Position + new Vector3(0, 1, 0);
            var missDistance = Vector3.Distance(position, lastBlockPos);

            return missDistance;
        }
        private ITowerBlock GetLastBlock()
        {
            return _blocks.Count == 0 ? null : _blocks.Last();
        }

        private void OnBlockPlaced(BlockPlaceResult placeResult)
        {
            GetLastBlock().Physics = !placeResult.IsSuccess;

            if (!placeResult.IsSuccess)
            {
                OnFail();
            }
        }

        private void OnFail()
        {
            _isFailed = true;
            Failed?.Invoke();
        }
    }
}