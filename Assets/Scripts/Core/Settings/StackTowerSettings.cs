using Core.Tower;
using UnityEngine;

namespace Core.Settings
{
    [CreateAssetMenu(menuName = "Stack/Tower Settings")]
    public class StackTowerSettings : ScriptableObject, IStackTowerSettings
    {
        public int InitialBlocksCount => _initialBlocksCount;

        [SerializeField, Min(0)] private int _initialBlocksCount;
    }
}