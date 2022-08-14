using System;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Tower.Blocks
{
    [Serializable]
    public class BlockSplitter
    {
        [SerializeField, Required] private GameObject _model;

        private ITowerBlockSettings _towerBlockSettings;
        private Vector3 _towerCenter;
        
        private Vector3 _modelPosition
        {
            get => _model.transform.position;
            set => _model.transform.position = value;
        }
        
        public void Initialize(ITowerBlockSettings towerBlockSettings, Vector3 towerCenter)
        {
            _towerBlockSettings = towerBlockSettings;
            _towerCenter = towerCenter;
        }
        public Vector3 Split(float missDistance, bool isXMovement)
        {
            if (missDistance == 0)
                return _modelPosition;

            var widthAlignModifier = 
                !isXMovement 
                ? _modelPosition.x >= _towerCenter.x ? 1 : -1
                : _modelPosition.z <= _towerCenter.z ? -1 : 1;

            var widthToSave = _towerBlockSettings.Width - missDistance;
            var widthToCut = _towerBlockSettings.Width - widthToSave;
            _model.transform.localScale = ValueToCorrectAxis(ConvertWidthToScale(widthToSave), isXMovement, Vector3.one);
            _modelPosition = ValueToCorrectAxis(widthAlignModifier * (widthToCut / 2), isXMovement, _modelPosition);

            return _modelPosition;
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