using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tweening.Operations
{
    public class PathMovement : ITweenOperation
    {
        public event Action<ITweenOperation> Complete;
        
        private readonly Transform _transform;
        private readonly Vector3[] _path;
        private readonly float _speed;
        private readonly float _accuracyTolerance;

        private int _currentWaypointIndex;
        private bool _isCompleted;
        
        public PathMovement(Transform transform, Vector3[] path, float speed, float accuracyTolerance = 0.1f)
        {
            _transform = transform;
            _path = path;
            _speed = speed;
            _accuracyTolerance = accuracyTolerance;
        }

        public void Update()
        {
            if(_isCompleted)
                return;
            
            var currentWaypoint = _path[_currentWaypointIndex];
            _transform.position = Vector3.MoveTowards(_transform.position, currentWaypoint, _speed);

            float distanceToCurrentWaypoint = Vector3.Distance(_transform.position, currentWaypoint);
            if (distanceToCurrentWaypoint <= _accuracyTolerance)
            {
                SwitchToNextWaypoint();
            }
        }

        private void SwitchToNextWaypoint()
        {
            _currentWaypointIndex++;

            if (_currentWaypointIndex + 1 >= _path.Length)
            {
                CompleteOperation();
            }
        }

        private void CompleteOperation()
        {
            _isCompleted = true;
            Complete?.Invoke(this);
        }
    }
}