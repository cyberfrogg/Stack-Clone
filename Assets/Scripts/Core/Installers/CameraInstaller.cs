using System;
using Core.Camera;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Installers
{
    [Serializable]
    public class CameraInstaller
    {
        [SerializeField, Required] private CameraBase _camera;
        
        public ICamera GetCamera()
        {
            return _camera;
        }
    }
}