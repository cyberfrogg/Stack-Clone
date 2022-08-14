using System;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Tower.Blocks
{
    [Serializable]
    public class BlockSplitter
    {
        private ITowerBlock _block;
        private ITowerBlockSettings _towerBlockSettings;
        private Vector3 _center;

        public void Initialize(ITowerBlockSettings towerBlockSettings, ITowerBlock block)
        {
            _towerBlockSettings = towerBlockSettings;
            _block = block;
        }
        public void Split(float missDistance, bool isZMovement)
        {
            if (missDistance == 0)
                return;
            
            var widthAlignModifier = 
                !isZMovement 
                    ? _block.Position.x >= _center.x ? 1 : -1
                    : _block.Position.z <= _center.z ? -1 : 1;

            var centerCoordinate = isZMovement ? _center.z : _center.x;
            var scaleCoordinate = isZMovement ? _block.Scale.z : _block.Scale.x;
            var currentPosCoordinate = isZMovement ? _block.Position.z : _block.Position.x;
            
            var widthToSave = Mathf.Abs(scaleCoordinate - missDistance);
            var widthToCut = Mathf.Abs(scaleCoordinate - Mathf.Abs(scaleCoordinate - missDistance));
            
            _block.Scale = ValueToCorrectAxis(widthToSave, isZMovement, _block.Scale);
            _block.Position = ValueToCorrectAxis(widthAlignModifier * (widthToSave / 2), isZMovement, _block.Position);
            
            Debug.Log($"axis: {(isZMovement ? "Z" : "X")}");
            Debug.Log($"miss: {(missDistance)}");
            Debug.Log($"centerCoordinate: {centerCoordinate}");
            Debug.Log($"scaleCoordinate: {scaleCoordinate}");
            Debug.Log($"Width to save: {widthToSave}");
            Debug.Log($"Width to cut: {widthToCut}");
        }

        private void CreateDebugGO(Vector3 pos)
        {
            GameObject debug = GameObject.CreatePrimitive(PrimitiveType.Cube);
            debug.transform.localScale = Vector3.one * 0.1f;
            debug.transform.position = pos;
        }
        
        private Vector3 ValueToCorrectAxis(float value, bool isZMovement, Vector3 initialPosition)
        {
            return !isZMovement
                ? new Vector3(value, initialPosition.y, initialPosition.z)
                : new Vector3(initialPosition.x, initialPosition.y, value);
        }
    }
}