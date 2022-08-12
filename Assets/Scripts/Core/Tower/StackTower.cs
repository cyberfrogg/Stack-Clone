using System.Collections.Generic;
using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Tower
{
    public class StackTower
    {
        private readonly IStackTowerSettings _settings;

        private readonly List<TowerBlock> _blocks = new();

        public StackTower(IStackTowerSettings settings)
        {
            _settings = settings;
        }

        public void PlaceBlock(TowerBlock block)
        {
            AlignBlock(block, _blocks.Count);
            _blocks.Add(block);
        }

        private void AlignBlock(TowerBlock block, int blocksCount)
        {
            block.transform.position = new Vector3(0, blocksCount * _settings.BlockHeight + (_settings.BlockHeight / 2), 0);
        }
    }
}