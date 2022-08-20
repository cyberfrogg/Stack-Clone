using Core.Camera;
using UnityEngine;
using Utils;

namespace Core.Tower.Blocks
{
    public interface ITowerBlock : IDestroy, ICameraTarget
    {
        Vector3 Position { get; set; }
        Vector3 Scale { get; set; }
        bool Physics { get; set; }
        void StartMovement(float yPosition, BlockMovementPathGenerator movementPathGenerator);
        BlockPlaceResult Drop(float missDistance, ITowerBlock lastBlock);
    }
}