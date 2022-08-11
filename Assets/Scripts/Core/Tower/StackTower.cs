using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Tower
{
    public class StackTower
    {
        private readonly IStackTowerSettings _settings;

        public StackTower(IStackTowerSettings settings)
        {
            _settings = settings;
        }

        public void PlaceBlock(TowerBlock block)
        {
            
        }
    }
}