using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
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
        
        private Tween _movementTween;
        private Vector3 _currentTweenPosition;
        private bool _isTweened;

        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }

        public void StartMovement(float yPosition, BlockMovementPathGenerator movementPathGenerator)
        {
            _isTweened = true;
            
            var waypoints = movementPathGenerator.GetNext(_blockSize, yPosition);
            AlignSelfAtStart(waypoints, yPosition);
            var path = new Path(PathType.Linear, waypoints.ToArray(), 5, Color.green);

            transform.DOKill();
            _movementTween = transform.DOPath(path,
                    _movementDuration,
                    PathMode.TopDown2D)
                .SetEase(Ease.Linear).SetLoops(-1);
        }
        public void Drop()
        {
            transform.DOKill();
            _movementTween?.Kill();
            _movementTween = null;
            transform.position = _isTweened ? _currentTweenPosition : transform.position;
        }

        private void Update()
        {
            _currentTweenPosition = transform.position;
        }

        private void AlignSelfAtStart(IEnumerable<Vector3> path, float yPosition)
        {
            transform.position = 
                path.First().x == 0
                    ? new Vector3(transform.position.z, yPosition, _blockSize)
                    : new Vector3(_blockSize, yPosition, transform.position.z);
        }
    }
}