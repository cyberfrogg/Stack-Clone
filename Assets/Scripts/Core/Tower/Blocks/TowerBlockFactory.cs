using System.Collections.Generic;
using UnityEngine;

namespace Core.Tower.Blocks
{
    public class TowerBlockFactory : ITowerBlocksFactory
    {
        private readonly TowerBlock _blockPrefab;

        public TowerBlockFactory(TowerBlock blockPrefab)
        {
            _blockPrefab = blockPrefab;
        }
        
        public TowerBlock CreateBlock()
        {
            var block = GameObject.Instantiate(_blockPrefab);
            Debug.Log("instantiating block prefab");
            return block;
        }
    }
}