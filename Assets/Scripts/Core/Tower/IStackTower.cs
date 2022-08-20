using System;
using Core.Camera;
using Core.Tower.Blocks;
using UnityEngine;
using Utils;

namespace Core.Tower
{
    public interface IStackTower : IDestroy
    {
        event Action Failed;
        event Action<BlockPlaceResult> BlockPlaced;
        Vector3 NextBlockPosition { get; }
        ITowerBlock LastBlock { get; }
        void PlaceBlock(ITowerBlock block, Action<BlockPlaceResult> blockPlaceComplete);
    }
}