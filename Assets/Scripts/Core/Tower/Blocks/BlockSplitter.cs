using System;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace Core.Tower.Blocks
{
    [Serializable]
    public class BlockSplitter
    {
        private ITowerBlocksFactory _towerBlocksFactory;
        private ITowerBlock _block;
        private ITowerBlock _lastBlock;

        public void Initialize(ITowerBlocksFactory towerBlocksFactory, ITowerBlock block, ITowerBlock lastBlock)
        {
            _towerBlocksFactory = towerBlocksFactory;
            _block = block;
            _lastBlock = lastBlock;
        }
        public BlockPlaceResult Split(float missDistance, bool isZMovement)
        {
            if (missDistance == 0)
                return new BlockPlaceResult(true);

            var widthAlignModifier = 
                !isZMovement 
                ? _block.Position.x >= _lastBlock.Position.x ? 1 : -1
                : _block.Position.z <= _lastBlock.Position.z ? -1 : 1;

            var axisScale = isZMovement ? _block.Scale.z : _block.Scale.x;
            var axisPosition = isZMovement ? _block.Position.z : _block.Position.x;

            var widthToSave = axisScale - missDistance;
            var widthToCut = axisScale - widthToSave;
            var blockTargetScale = axisScale - widthToCut;

            if (blockTargetScale <= 0)
                return new BlockPlaceResult(false);

            if (missDistance >= _block.Scale.magnitude)
                return new BlockPlaceResult(false);
            
            _block.Scale = ValueToCorrectAxis(Mathf.Abs(axisScale - widthToCut), isZMovement, _block.Scale);
            _block.Position = ValueToCorrectAxis(axisPosition + (-widthAlignModifier * widthToCut * 0.5f), isZMovement, _block.Position);

            var cutBlockPart = CreateCutBlockPart();
            cutBlockPart.Scale = ValueToCorrectAxis(Mathf.Abs(axisScale - widthToSave), isZMovement, _block.Scale);
            cutBlockPart.Position = ValueToCorrectAxis(axisPosition + (widthAlignModifier * widthToSave * 0.5f), isZMovement, _block.Position);
            
            return new BlockPlaceResult(true);
        }

        private Vector3 ValueToCorrectAxis(float value, bool isXMovement, Vector3 initialPosition)
        {
            return !isXMovement
                ? new Vector3(value, initialPosition.y, initialPosition.z)
                : new Vector3(initialPosition.x, initialPosition.y, value);
        }
        private CutBlockPart CreateCutBlockPart()
        {
            return _towerBlocksFactory.CreateCutBlockPart();
        }
    }
}