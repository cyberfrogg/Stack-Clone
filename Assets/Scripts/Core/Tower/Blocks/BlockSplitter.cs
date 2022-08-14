using System;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Tower.Blocks
{
    [Serializable]
    public class BlockSplitter
    {
        public Vector3 ModelPosition
        {
            get => _model.transform.position;
            private set => _model.transform.position = value;
        }
        public Vector3 ModelScale
        {
            get => _model.transform.localScale;
            private set => _model.transform.localScale = value;
        }
        
        [SerializeField, Required] private GameObject _model;

        private ITowerBlockSettings _towerBlockSettings;
        private Vector3 _center;

        public void Initialize(ITowerBlockSettings towerBlockSettings, Vector3 center, Vector3 scale)
        {
            _towerBlockSettings = towerBlockSettings;
            _center = center;
            ModelScale = scale;
        }
        public void Split(float missDistance, bool isZMovement)
        {
            if (missDistance == 0)
                return;

            int widthAlignModifier = 0;
            
            if (!isZMovement)
            {
                if (ModelPosition.x >= _center.x)
                {
                    var widthToSave = _towerBlockSettings.Width - missDistance;
                    var widthToCut = _towerBlockSettings.Width - widthToSave;
                    _model.transform.localScale = ValueToCorrectAxis(ConvertWidthToScale(widthToSave), isZMovement, ModelScale);
                    ModelPosition = ValueToCorrectAxis((widthToCut / 2), isZMovement, ModelPosition);
                    Debug.Log("Z movement && _modelPosition.x >= _towerCenter.x");
                }
                else
                {
                    var widthToSave = _towerBlockSettings.Width - missDistance;
                    var widthToCut = _towerBlockSettings.Width - widthToSave;
                    _model.transform.localScale = ValueToCorrectAxis(ConvertWidthToScale(widthToSave), isZMovement, ModelScale);
                    ModelPosition = ValueToCorrectAxis(-(widthToCut / 2), isZMovement, ModelPosition);
                    Debug.Log("Z movement && _modelPosition.x < _towerCenter.x");
                }
            }
            else
            {
                if (ModelPosition.z <= _center.z)
                {
                    var widthToSave = _towerBlockSettings.Width - missDistance;
                    var widthToCut = _towerBlockSettings.Width - widthToSave;
                    _model.transform.localScale = ValueToCorrectAxis(ConvertWidthToScale(widthToSave), isZMovement, ModelScale);
                    ModelPosition = ValueToCorrectAxis(-(widthToCut / 2), isZMovement, ModelPosition);
                    Debug.Log("X movement && _modelPosition.x <= _towerCenter.x");
                }
                else
                {
                    var widthToSave = _towerBlockSettings.Width - missDistance;
                    var widthToCut = _towerBlockSettings.Width - widthToSave;
                    _model.transform.localScale = ValueToCorrectAxis(ConvertWidthToScale(widthToSave), isZMovement, ModelScale);
                    ModelPosition = ValueToCorrectAxis((widthToCut / 2), isZMovement, ModelPosition);
                    Debug.Log("X movement && _modelPosition.x > _towerCenter.x");
                }
            }
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