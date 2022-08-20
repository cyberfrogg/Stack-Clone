using Core.Tower.Blocks;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Settings
{
    [CreateAssetMenu(menuName = "Stack/Tower Block Settings")]
    public class TowerBlockSettings : ScriptableObject, ITowerBlockSettings
    {
        [SerializeField, Min(0)] private float _width = 5;
        [SerializeField, Min(0)] private float _height = 1;
        [SerializeField, Min(0)] private float _moveDuration = 4;
        [Space] 
        [SerializeField, Required] private StackTowerSettings _stackTowerSettings;

        public float Width => _width;
        public float MovementDuration => _moveDuration;
        public float Height => _height;
        public Vector3 TowerCenter => _stackTowerSettings.Center;

    }
}