using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Core.Tower.Blocks
{
    public class TowerBlock : MonoBehaviour, IDestroy
    {
        [SerializeField, Min(0)] private float _blockSize = 5;
        [SerializeField, Min(0)] private float _movementDuration = 4;
        
        private Sequence _movementSequence;
        
        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }

        public void StartMovement(float yPosition, BlockMovementPathGenerator movementPathGenerator)
        {
            var waypoints = movementPathGenerator.GetNext(_blockSize, yPosition);
            AlignSelfAtStart(waypoints, yPosition);
            var path = new Path(PathType.Linear, waypoints.ToArray(), 5, Color.green);
            
            _movementSequence = DOTween.Sequence();
            _movementSequence.Append(transform.DOPath(path,
                    _movementDuration,
                    PathMode.TopDown2D)
                .SetEase(Ease.Linear)
                .SetLoops(-1));
        }

        private void AlignSelfAtStart(IEnumerable<Vector3> path, float yPosition)
        {
            transform.position = 
                path.First().x == 0
                ? new Vector3(transform.position.z, yPosition, _blockSize)
                : new Vector3(_blockSize, yPosition, transform.position.z);
        }

        public void Drop()
        {
            _movementSequence?.Kill();
        }
    }
}