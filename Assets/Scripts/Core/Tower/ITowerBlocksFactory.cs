using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Tower
{
    public interface ITowerBlocksFactory
    {
        ITowerBlock CreateBlock();
        ITowerBlock CreateBlock(ITowerBlock lastBlock);
    }
}