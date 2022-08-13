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

        public void StartMovement(float yPosition)
        {
            transform.position = new Vector3(_blockSize, yPosition, transform.position.z);
            
            _movementSequence = DOTween.Sequence();
            _movementSequence.Append(transform.DOPath(GetMovementPath(),
                    _movementDuration,
                    PathMode.TopDown2D)
                .SetEase(Ease.Linear)
                .SetLoops(-1));
        }

        public void Drop()
        {
            _movementSequence?.Kill();
        }

        private Path GetMovementPath()
        {
            var yPosition = transform.position.y;
            var waypoints = new Vector3[]
            {
                new (_blockSize, yPosition, 0),
                new (-_blockSize, yPosition, 0),
                new (_blockSize, yPosition, 0)
            };

            return new Path(PathType.Linear, waypoints, 5, Color.green);
        }
    }
}