using UnityEngine;

namespace Core.Camera
{
    public interface ICameraTarget
    {
        Transform Target { get; }   
    }
}