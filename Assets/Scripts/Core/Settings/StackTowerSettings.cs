using Core.Tower;
using UnityEngine;

namespace Core.Settings
{
    [CreateAssetMenu(menuName = "Stack/Tower Settings")]
    public class StackTowerSettings : ScriptableObject, IStackTowerSettings
    {
        public int InitialBlocksCount => _initialBlocksCount;
        public float BlockHeight => _blockHeight;

        [SerializeField, Min(0)] private int _initialBlocksCount = 4;
        [SerializeField, Min(0)] private float _blockHeight = 1f;
    }
}