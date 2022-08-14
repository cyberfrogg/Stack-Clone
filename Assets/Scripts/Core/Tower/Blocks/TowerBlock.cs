using System.Collections.Generic;
using System.Linq;
using Tweening;
using Tweening.Operations;
using UnityEngine;

namespace Core.Tower.Blocks
{
    public class TowerBlock : MonoBehaviour, ITowerBlock
    {
        [SerializeField] private BlockSplitter _blockSplitter;
        
        private ITowerBlockSettings _settings;
        private SimpleTweener _simpleTweener;
        private Vector3 _towerCenter;

        private ITweenOperation _currentTween;
        private bool _isZMovement;
        
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        
        public void Initialize(ITowerBlockSettings settings, SimpleTweener simpleTweener)
        {
            _settings = settings;
            _simpleTweener = simpleTweener;
            _towerCenter = _settings.TowerCenter;
            _blockSplitter.Initialize(_settings, _towerCenter);
        }
        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }

        public void StartMovement(float yPosition, BlockMovementPathGenerator movementPathGenerator)
        {
            var waypoints = movementPathGenerator.GetNext(_settings.Width, yPosition);
            _isZMovement = GetIsXMovement(waypoints);
            AlignSelfAtStart(yPosition);

            RunPathTween(waypoints);
        }
        public void Drop(float missDistance)
        {
            _currentTween?.Stop();
            _blockSplitter.Split(missDistance, _isZMovement);
        }

        private void AlignSelfAtStart(float yPosition)
        {
            transform.position = 
                _isZMovement
                    ? new Vector3(transform.position.z, yPosition, _settings.Width)
                    : new Vector3(_settings.Width, yPosition, transform.position.z);
        }
        private void RunPathTween(IEnumerable<Vector3> waypoints)
        {
            _currentTween = CreatePathTween(waypoints);
            _currentTween.Complete += (ITweenOperation _) =>
            {
                RunPathTween(waypoints);
            };
            _simpleTweener.Run(_currentTween);
        }
        private ITweenOperation CreatePathTween(IEnumerable<Vector3> waypoints)
        {
            return new PathMovement(transform, waypoints.ToArray(), _settings.MovementDuration);
        }

        private bool GetIsXMovement(IEnumerable<Vector3> waypoints)
        {
            return waypoints.First().x == 0;
        }
    }
}