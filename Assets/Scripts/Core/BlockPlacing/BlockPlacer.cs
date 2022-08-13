using Core.Tower;
using Core.Tower.Blocks;
using Utils;

namespace Core.BlockPlacing
{
    public class BlockPlacer : IDestroyable
    {
        private readonly IBlockPlacerInput _input;
        private readonly IStackTower _tower;
        private readonly ITowerBlocksFactory _towerBlockFactory;

        public BlockPlacer(IBlockPlacerInput input, IStackTower tower, ITowerBlocksFactory towerBlockFactory)
        {
            _input = input;
            _tower = tower;
            _towerBlockFactory = towerBlockFactory;

            _input.Pressed += OnInputPress;
        }

        public void Destroy()
        {
            _input.Pressed -= OnInputPress;
        }

        private void OnInputPress()
        {
            var block = _towerBlockFactory.CreateBlock();
            _tower.PlaceBlock(block);
        }
    }
}