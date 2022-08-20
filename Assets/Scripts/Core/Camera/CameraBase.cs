using Cinemachine;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Camera
{
    public class CameraBase : MonoBehaviour, ICamera
    {
        [SerializeField, Required] private CinemachineVirtualCamera _cinemachine;
        
        public void SetTarget(ICameraTarget target)
        {
            var transformTarget  = target != null ? target.Target : null;
            
            _cinemachine.m_Follow = transformTarget;
            _cinemachine.m_LookAt = transformTarget;
        }
    }
}
