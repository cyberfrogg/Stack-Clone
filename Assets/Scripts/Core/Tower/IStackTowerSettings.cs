using UnityEngine;

namespace Core.Tower
{
    public interface IStackTowerSettings
    {
        Vector3 Center { get; }
        int InitialBlocksCount { get; }
        float BlockHeight { get; }
        float MissPlacingTolerance { get; }
    }
}