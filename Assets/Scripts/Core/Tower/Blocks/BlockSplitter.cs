using System;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Tower.Blocks
{
    [Serializable]
    public class BlockSplitter
    {
        private ITowerBlockSettings _towerBlockSettings;
        private ITowerBlock _block;
        private ITowerBlock _lastBlock;

        public void Initialize(ITowerBlockSettings towerBlockSettings, ITowerBlock block, ITowerBlock lastBlock)
        {
            _towerBlockSettings = towerBlockSettings;
            _block = block;
            _lastBlock = lastBlock;
        }
        public void Split(float missDistance, bool isZMovement)
        {
            if (missDistance == 0)
                return;

            var widthAlignModifier = 
                !isZMovement 
                ? _block.Position.x >= _lastBlock.Position.x ? 1 : -1
                : _block.Position.z <= _lastBlock.Position.z ? -1 : 1;

            var axisScale = isZMovement ? _block.Scale.z : _block.Scale.x;

            var widthToSave = axisScale - missDistance;
            var widthToCut = axisScale - widthToSave;
            _block.Scale = ValueToCorrectAxis(widthToSave, isZMovement, _block.Scale);
            _block.Position = ValueToCorrectAxis((widthAlignModifier * widthToCut) / 2, isZMovement, _block.Position);
            
            Debug.Log($"Miss distance: {missDistance}");
            Debug.Log($"widthAlignModifier: {widthAlignModifier}");
            Debug.Log($"axisScale: {axisScale}");
            Debug.Log($"widthToSave: {widthToSave}");
            Debug.Log($"widthToCut: {widthToCut}");
            Debug.Log($"_block.Scale: {_block.Scale}");
            Debug.Log($"_block.Position: {_block.Position}");
            Debug.Log($"----------------");

        }
        
        private float ConvertWidthToScale(float width)
        {
            return width / _towerBlockSettings.Width;
        }

        private Vector3 ValueToCorrectAxis(float value, bool isXMovement, Vector3 initialPosition)
        {
            return !isXMovement
                ? new Vector3(value, initialPosition.y, initialPosition.z)
                : new Vector3(initialPosition.x, initialPosition.y, value);
        }
    }
}