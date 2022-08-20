using System;
using UnityEngine;

namespace Core.Tower.Blocks
{
    public class CutBlockPart : MonoBehaviour
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        public Vector3 Scale
        {
            get => transform.localScale;
            set => transform.localScale = value;
        }
    }
}