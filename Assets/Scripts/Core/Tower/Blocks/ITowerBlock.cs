using UnityEngine;
using Utils;

namespace Core.Tower.Blocks
{
    public interface ITowerBlock : IDestroy
    {
        Vector3 Position { get; set; }
        Vector3 Scale { get; set; }
        void StartMovement(float yPosition, BlockMovementPathGenerator movementPathGenerator);
        void Drop(float missDistance, ITowerBlock lastBlock);
    }
}