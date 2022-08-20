
using UnityEngine;

namespace Core.Tower.Blocks
{
    public interface ITowerBlockSettings
    {
        float Width { get; }
        float Height { get; }
        float MovementDuration { get; }
        Vector3 TowerCenter { get; }
    }
}