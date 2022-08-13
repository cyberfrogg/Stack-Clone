using Core.Tower;

namespace Core.BlockPlacing
{
    public class BlockPlacerFactory
    {
        private readonly IBlockPlacerInput _input;
        private readonly ITowerBlocksFactory _blockPlacerFactory;

        public BlockPlacerFactory(IBlockPlacerInput input, ITowerBlocksFactory blockPlacerFactory)
        {
            _input = input;
            _blockPlacerFactory = blockPlacerFactory;
        }

        public BlockPlacer CreateBlockPlacer(IStackTower tower)
        {
            return new BlockPlacer(_input, tower, _blockPlacerFactory);
        }
    }
}