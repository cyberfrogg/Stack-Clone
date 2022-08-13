using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Tower
{
    public interface IStackTower
    {
        void PlaceBlock(TowerBlock block);
    }
}