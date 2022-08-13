using Core.Tower.Blocks;

namespace Core.Tower
{
    public interface ITowerBlocksFactory
    {
        ITowerBlock CreateBlock();
        ITowerBlock CreateBlock(float width);
    }
}