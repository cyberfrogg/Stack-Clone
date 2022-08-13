using System;
using Core.BlockPlacing;
using Core.Tower;
using Core.UI.Controls.BlockPlacing;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Installers
{
    [Serializable]
    public class BlockPlacerInstaller
    {
        [SerializeField, Required] private BlockPlacerTouchInput _touchInput;

        public BlockPlacerFactory CreateFactory(ITowerBlocksFactory towerBlocksFactory)
        {
            return new BlockPlacerFactory(_touchInput, towerBlocksFactory);
        }
    }
}