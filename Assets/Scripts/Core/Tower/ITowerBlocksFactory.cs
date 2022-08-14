using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Tower
{
    public interface ITowerBlocksFactory
    {
        ITowerBlock CreateBlock();
        ITowerBlock CreateBlock(Vector3 lastBlockCenter, Vector3 lastBlockScale);
    }
}