using System;
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
        private Vector3 _lastBlockCenter;
        private Vector3 _lastBlockScale;

        private ITweenOperation _currentTween;
        private bool _isZMovement;

        [Header("debug:")] 
        [SerializeField] private Vector3 _debug_center;
        [SerializeField] private Vector3 _debug_lastBlockCenter;
        [SerializeField] private Vector3 _debug_lastBlockScale;
        
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        public Vector3 Center { get; private set; }
        public Vector3 Scale { get; private set; }
        
        public void Initialize(ITowerBlockSettings settings, SimpleTweener simpleTweener, Vector3 lastBlockCenter, Vector3 lastBlockScale)
        {
            _settings = settings;
            _simpleTweener = simpleTweener;
            _lastBlockCenter = lastBlockCenter;
            _lastBlockScale = lastBlockScale;
            _blockSplitter.Initialize(_settings, _lastBlockCenter, _lastBlockScale);
        }
        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }

        public void StartMovement(float yPosition, BlockMovementPathGenerator movementPathGenerator)
        {
            var waypoints = movementPathGenerator.GetNext(_settings.Width, yPosition);
            _isZMovement = GetIsZMovement(waypoints);
            waypoints = OffsetWaypointsToLastCenter(waypoints);
            AlignSelfAtStart(yPosition);

            RunPathTween(waypoints);
        }
        public void Drop(float missDistance, ITowerBlock lastBlock)
        {
            _currentTween?.Stop();

            if (lastBlock == null) return;
            
            _blockSplitter.Split(missDistance, _isZMovement);
            Center = _blockSplitter.ModelPosition;
            Scale = _blockSplitter.ModelScale;
        }

        private void AlignSelfAtStart(float yPosition)
        {
            var target = 
                _isZMovement
                    ? new Vector3(transform.position.z, yPosition, _settings.Width)
                    : new Vector3(_settings.Width, yPosition, transform.position.z);

            transform.position = OffsetPositionToLastCenter(target);
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
        private IEnumerable<Vector3> OffsetWaypointsToLastCenter(IEnumerable<Vector3> waypoints)
        {
            return waypoints
                .Select(x => OffsetPositionToLastCenter(x))
                .ToList();
        }
        private Vector3 OffsetPositionToLastCenter(Vector3 position)
        {
            return position + new Vector3(_lastBlockCenter.x, 0, _lastBlockCenter.z);
        }
        private bool GetIsZMovement(IEnumerable<Vector3> waypoints)
        {
            return waypoints.First().x == 0;
        }

        private void Update()
        {
            _debug_center = Center;
            _debug_lastBlockCenter = _lastBlockCenter;
            _debug_lastBlockScale = _lastBlockScale;
        }
    }
}