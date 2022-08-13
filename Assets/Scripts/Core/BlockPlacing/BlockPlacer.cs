using System.Numerics;
using Core.Tower;
using Core.Tower.Blocks;
using Utils;

namespace Core.BlockPlacing
{
    public class BlockPlacer : IDestroy
    {
        private readonly IBlockPlacerInput _input;
        private readonly IStackTower _tower;
        private readonly ITowerBlocksFactory _towerBlockFactory;
        private readonly BlockMovementPathGenerator _blockMovementPathGenerator;

        private TowerBlock _currentBlock;

        public BlockPlacer(IBlockPlacerInput input,
            IStackTower tower,
            ITowerBlocksFactory towerBlockFactory,
            BlockMovementPathGenerator blockMovementPathGenerator)
        {
            _input = input;
            _tower = tower;
            _towerBlockFactory = towerBlockFactory;
            _blockMovementPathGenerator = blockMovementPathGenerator;

            _input.Pressed += OnInputPress;
        }
        public void Destroy()
        {
            _input.Pressed -= OnInputPress;
        }

        public void CreateMovingBlock()
        {
            _currentBlock = _towerBlockFactory.CreateBlock();
            _currentBlock.StartMovement(_tower.NextBlockPosition.y, _blockMovementPathGenerator);
        }

        private void OnInputPress()
        {
            if(_currentBlock == null)
                return;
            
            _tower.PlaceBlock(_currentBlock);
            OnBlockPlaced();
        }

        private void OnBlockPlaced()
        {
            CreateMovingBlock();
        }
    }
}