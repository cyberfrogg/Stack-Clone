using Core.Tower.Blocks;
using UnityEngine;
using Utils;

namespace Core.Tower
{
    public interface IStackTower : IDestroy
    {
        Vector3 NextBlockPosition { get; }
        ITowerBlock LastBlock { get; }
        void PlaceBlock(ITowerBlock block);
    }
}