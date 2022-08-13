using UnityEngine;

namespace Core.Tower
{
    public class StackTowerFactory
    {
        private readonly IStackTowerSettings _settings;
        private readonly ITowerBlocksFactory _towerBlocksFactory;

        public StackTowerFactory(IStackTowerSettings settings, ITowerBlocksFactory towerBlocksFactory)
        {
            _settings = settings;
            _towerBlocksFactory = towerBlocksFactory;
        }

        public StackTower CreateTower()
        {
            StackTower stackTower = new StackTower(_settings);

            for (int i = 0; i < _settings.InitialBlocksCount; i++)
            {
                stackTower.PlaceBlock(_towerBlocksFactory.CreateBlock());
            }
            
            return stackTower;
        }
    }
}