using Core.Tower.Blocks;
using UnityEngine;
using Utils;

namespace Core.Tower
{
    public interface IStackTower : IDestroy
    {
        void PlaceBlock(TowerBlock block);
    }
}