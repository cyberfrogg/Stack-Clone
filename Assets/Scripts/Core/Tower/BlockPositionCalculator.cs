using UnityEngine;

namespace Core.Tower
{
    public class BlockPositionCalculator
    {
        private readonly float _blockHeight;

        public BlockPositionCalculator(float blockHeight)
        {
            _blockHeight = blockHeight;
        }

        public Vector3 GetNextPosition(int blocksCount)
        {
            return new Vector3(0, blocksCount * _blockHeight + (_blockHeight / 2), 0);
        }
    }
}