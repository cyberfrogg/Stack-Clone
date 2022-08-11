using Core.Tower.Blocks;

namespace Core.Tower
{
    public interface ITowerBlocksFactory
    {
        TowerBlock CreateBlock();
    }
}