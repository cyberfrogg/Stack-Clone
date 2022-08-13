using Core.Tower.Blocks;
using UnityEngine;

namespace Core.Settings
{
    [CreateAssetMenu(menuName = "Stack/Tower Block Settings")]
    public class TowerBlockSettings : ScriptableObject, ITowerBlockSettings
    {
        [SerializeField, Min(0)] private float _width;
        [SerializeField, Min(0)] private float _moveDuration;

        public float Width => _width;
        public float MovementDuration => _moveDuration;
    }
}