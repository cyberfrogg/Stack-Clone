using UnityEngine;
using Utils;

namespace Core.Tower.Blocks
{
    public class TowerBlock : MonoBehaviour, IDestroy
    {
        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }
    }
}