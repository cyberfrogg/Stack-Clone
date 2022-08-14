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
        private ITowerBlock _lastBlock;

        private ITweenOperation _currentTween;
        private bool _isZMovement;
        
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
        
        public void Initialize(ITowerBlockSettings settings, SimpleTweener simpleTweener, ITowerBlock lastBlock)
        {
            _settings = settings;
            _simpleTweener = simpleTweener;
            _lastBlock = lastBlock;
            _blockSplitter.Initialize(_settings, this);

            TransformAsBlock(_lastBlock);
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
            return position + new Vector3(_lastBlock.Position.x, 0, _lastBlock.Position.z);
        }
        private bool GetIsZMovement(IEnumerable<Vector3> waypoints)
        {
            return waypoints.First().x == 0;
        }
        private void TransformAsBlock(ITowerBlock block)
        {
            if(block == null)
                return;
            
            Position = block.Position;
            Scale = block.Scale;
        }
    }
}