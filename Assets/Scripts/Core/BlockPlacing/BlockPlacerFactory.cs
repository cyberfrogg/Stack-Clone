using Core.Tower;
using Core.Tower.Blocks;

namespace Core.BlockPlacing
{
    public class BlockPlacerFactory
    {
        private readonly IBlockPlacerInput _input;
        private readonly ITowerBlocksFactory _towerBlocksFactory;
        private readonly BlockMovementPathGenerator _blockMovementPathGenerator;

        public BlockPlacerFactory(IBlockPlacerInput input,
            ITowerBlocksFactory towerBlocksFactory,
            BlockMovementPathGenerator blockMovementPathGenerator)
        {
            _input = input;
            _towerBlocksFactory = towerBlocksFactory;
            _blockMovementPathGenerator = blockMovementPathGenerator;
        }

        public BlockPlacer CreateBlockPlacer(IStackTower tower)
        {
            return new BlockPlacer(_input, tower, _towerBlocksFactory, _blockMovementPathGenerator);
        }
    }
}