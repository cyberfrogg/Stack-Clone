using Cinemachine;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Camera
{
    public class CameraBase : MonoBehaviour, ICamera
    {
        [SerializeField, Required] private CinemachineVirtualCamera _cinemachine;
        [SerializeField, Required] private Transform _defaultTarget;
        
        public void SetTarget(ICameraTarget target)
        {
            var transformTarget  = target != null ? target.Target : null;
            
            _cinemachine.m_Follow = transformTarget;
            _cinemachine.m_LookAt = transformTarget;
        }

        public void ResetToDefaultTarget()
        {
            _cinemachine.m_Follow = _defaultTarget;
            _cinemachine.m_LookAt = _defaultTarget;
        }
    }
}
