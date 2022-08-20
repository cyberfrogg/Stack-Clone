using Core.Tower;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Settings
{
    [CreateAssetMenu(menuName = "Stack/Tower Settings")]
    public class StackTowerSettings : ScriptableObject, IStackTowerSettings
    {
        public Vector3 Center => _center;
        public int InitialBlocksCount => _initialBlocksCount;
        public float BlockHeight => _blockHeight;
        public float MissPlacingTolerance => _missPlacingTolerance;

        [SerializeField, Min(0)] private int _initialBlocksCount = 4;
        [SerializeField, Min(0)] private float _blockHeight = 1f;
        [SerializeField, ReadOnly] private Vector3 _center = Vector3.zero;
        [SerializeField, Min(0)] private float _missPlacingTolerance;
    }
}