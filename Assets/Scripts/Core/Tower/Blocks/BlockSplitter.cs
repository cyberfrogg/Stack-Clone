using System;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Tower.Blocks
{
    [Serializable]
    public class BlockSplitter
    {
        [SerializeField, Required] private GameObject _model;
        
        public void Split(float missDistance, bool isXMovement)
        {
            if (missDistance == 0)
                return;
            
            Debug.Log("Splitting..");
        }
    }
}