using System.Collections.Generic;
//using System.IO;
using System.Linq;
using Tweening;
using Tweening.Operations;
//using DG.Tweening;
//using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine;

namespace Core.Tower.Blocks
{
    public class TowerBlock : MonoBehaviour, ITowerBlock
    {
        private ITowerBlockSettings _settings;
        private SimpleTweener _simpleTweener;

        private ITweenOperation _currentTween;
        
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        
        public void Initialize(ITowerBlockSettings settings, SimpleTweener simpleTweener)
        {
            _settings = settings;
            _simpleTweener = simpleTweener;
        }
        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }

        public void StartMovement(float yPosition, BlockMovementPathGenerator movementPathGenerator)
        {
            var waypoints = movementPathGenerator.GetNext(_settings.Width, yPosition);
            AlignSelfAtStart(waypoints, yPosition);

            RunPathTween(waypoints);
        }
        public void Drop()
        {
            _currentTween?.Stop();
        }

        private void AlignSelfAtStart(IEnumerable<Vector3> path, float yPosition)
        {
            transform.position = 
                path.First().x == 0
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
    }
}