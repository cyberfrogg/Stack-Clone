using System;
using System.Collections.Generic;
using Core.BlockPlacing;
using Core.Tower;
using Core.Tower.Blocks;
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
            return new BlockPlacerFactory(_touchInput, towerBlocksFactory, GetBlockMovementPathGenerator());
        }

        private BlockMovementPathGenerator GetBlockMovementPathGenerator()
        {
            var paths = new List<List<Vector3>>
            {
                new()
                {
                    new Vector3(1, 0, 0),
                    new Vector3(-1, 0, 0),
                    new Vector3(1, 0, 0)
                },
                new()
                {
                    new Vector3(0, 0, 1),
                    new Vector3(0, 0, -1),
                    new Vector3(0, 0, 1)
                }
            };

            return new BlockMovementPathGenerator(paths);
        }
    }
}